using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Api.DistributedCaching;
using Ecommerce.Application.IRepository;
using EcommerceSystem.Application.DTOS;
using EcommerceSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
	private readonly ILogger<ProductController> _logger;

	private readonly IUniteOfWork _unitOfWork;

	private readonly IMapper _mapper;

	private readonly ICacheService _cache;

	public ProductController(ILogger<ProductController> logger, IUniteOfWork unitOfWork, IMapper mapper, ICacheService cache)
	{
		_logger = logger;
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_cache = cache;
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> GetProductById(int id)
	{
		string cacheKey = $"product:{id}";
		ProductDto cachedProduct = await _cache.GetAsync<ProductDto>(cacheKey);
		if (cachedProduct != null)
		{
			return Ok(cachedProduct);
		}
		Product product = await _unitOfWork.Products.GetByIdAsync(id);
		if (product == null)
		{
			return NotFound();
		}
		ProductDto dto = _mapper.Map<ProductDto>(product);
		await _cache.SetAsync(cacheKey, dto, TimeSpan.FromMinutes(10L));
		return Ok(dto);
	}

	[HttpPost]
	public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
	{
		_logger.LogInformation("Creating a new product");
		try
		{
			if (!base.ModelState.IsValid)
			{
				return BadRequest(base.ModelState);
			}
			Product productEntity = _mapper.Map<Product>(productDto);
			await _unitOfWork.Products.AddAsync(productEntity);
			await _unitOfWork.CompleteAsync();
			return Ok(productEntity);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError(ex2, "Error occurred while creating a new product");
			return StatusCode(500, "Internal server error");
		}
	}

	[HttpGet]
	[HttpGet]
	public async Task<IActionResult> GetAllProducts()
	{
		List<ProductDto> cachedProducts = await _cache.GetAsync<List<ProductDto>>("products");
		if (cachedProducts != null)
		{
			return Ok(cachedProducts);
		}
		IEnumerable<Product> products = await _unitOfWork.Products.GetAllAsync();
		List<ProductDto> dto = _mapper.Map<List<ProductDto>>(products);
		await _cache.SetAsync("products", dto, TimeSpan.FromMinutes(10L));
		return Ok(dto);
	}

	[HttpGet("GetProdcutsWithDetails")]
	public async Task<IActionResult> GetProduct([FromQuery] ProductQueryParameter query)
	{
		PageResult<Product> result = await _unitOfWork.Products.GetProductsAsync(query);
		List<ProductDto> dto = _mapper.Map<List<ProductDto>>(result.Items);
		return Ok(new
		{
			data = dto,
			pagination = new { result.TotalCount, result.PageNumber, result.PageSize, result.TotalPages }
		});
	}

	[HttpPut]
	public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
	{
		if (!base.ModelState.IsValid)
		{
			return BadRequest(base.ModelState);
		}
		Product productEntity = _mapper.Map<Product>(productDto);
		_unitOfWork.Products.Update(productEntity);
		await _unitOfWork.CompleteAsync();
		return Ok(productEntity);
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteProduct(int id)
	{
		Product product = await _unitOfWork.Products.GetByIdAsync(id);
		if (product == null)
		{
			return NotFound();
		}
		_unitOfWork.Products.Delete(product);
		await _unitOfWork.CompleteAsync();
		return NoContent();
	}
}
