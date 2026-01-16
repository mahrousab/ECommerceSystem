using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Application.IRepository;
using EcommerceSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EcommerceSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
	private readonly ILogger<ProductImagesController> _logger;

	private readonly IUniteOfWork _uniteOfWork;

	public ProductImagesController(ILogger<ProductImagesController> logger, IUniteOfWork uniteOfWork)
	{
		_uniteOfWork = uniteOfWork;
		_logger = logger;
	}

	[HttpGet]
	[Route("{id:int}")]
	public IActionResult GetProductImageById(int id)
	{
		ProductImage productImage = _uniteOfWork.ProductImage.GetById(id);
		if (productImage == null)
		{
			return NotFound();
		}
		return Ok(productImage);
	}

	[HttpGet]
	public IActionResult GetAllProductImages()
	{
		IEnumerable<ProductImage> productImages = _uniteOfWork.ProductImage.GetAll();
		return Ok(productImages);
	}

	[HttpPost]
	public async Task<IActionResult> CreateProductImage([FromBody] ProductImage productImage)
	{
		_logger.LogInformation("Creating a new product image");
		try
		{
			if (!base.ModelState.IsValid)
			{
				return BadRequest(base.ModelState);
			}
			await _uniteOfWork.ProductImage.AddAsync(productImage);
			await _uniteOfWork.CompleteAsync();
			return Ok(productImage);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError(ex2, "Error occurred while creating a new product image");
			return StatusCode(500, "Internal server error");
		}
	}

	[HttpDelete]
	[Route("{id:int}")]
	public async Task<IActionResult> DeleteProductImage(int id)
	{
		ProductImage productImage = await _uniteOfWork.ProductImage.GetByIdAsync(id);
		if (productImage == null)
		{
			return NotFound();
		}
		_uniteOfWork.ProductImage.Delete(productImage);
		await _uniteOfWork.CompleteAsync();
		return NoContent();
	}
}
