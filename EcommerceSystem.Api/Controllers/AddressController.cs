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

namespace EcommerceSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AddressController : ControllerBase
{
	private readonly ILogger<AddressController> _logger;

	private readonly IUniteOfWork _unitOfWork;

	private readonly IMapper _mapper;

	private readonly ICacheService _cache;

	public AddressController(IUniteOfWork unitOfWork, ILogger<AddressController> logger, IMapper mapper, ICacheService cache)
	{
		_unitOfWork = unitOfWork;
		_logger = logger;
		_mapper = mapper;
		_cache = cache;
	}

	[HttpGet]
	[Route("{id:int}")]
	public async Task<IActionResult> GetAddressById(int id)
	{
		_logger.LogInformation("Fetching address with ID: {Id}", id);
		string cacheKey = $"Address:{id}";
		AddressDTO cachedProduct = await _cache.GetAsync<AddressDTO>(cacheKey);
		if (cachedProduct != null)
		{
			return Ok(cachedProduct);
		}
		
			Address address = await _unitOfWork.Addresses.GetByIdAsync(id);
			if (address == null)
			{
				return NotFound();
			}
			CreateAddressDTO dto = _mapper.Map<CreateAddressDTO>(address);
			await _cache.SetAsync(cacheKey, dto, TimeSpan.FromMinutes(10L));
			return Ok(dto);	
	}

	[HttpPost]
	public async Task<IActionResult> CreateAddress([FromBody] CreateAddressDTO address)
	{
		_logger.LogInformation("Creating a new address");
		
			Address addressEntity = _mapper.Map<Address>(address);
			await _unitOfWork.Addresses.AddAsync(addressEntity);
			await _unitOfWork.CompleteAsync();
			return Ok(addressEntity);
		
		
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAddresses()
	{
		_logger.LogInformation("Fetching all addresses");
		List<ProductDto> cachedProducts = await _cache.GetAsync<List<ProductDto>>("Address:all");
		if (cachedProducts != null)
		{
			return Ok(cachedProducts);
		}
		
			IEnumerable<Address> addresses = await _unitOfWork.Addresses.GetAllAsync();
			IEnumerable<CreateAddressDTO> dto = _mapper.Map<IEnumerable<CreateAddressDTO>>(addresses);
			await _cache.SetAsync("Address:all", dto, TimeSpan.FromMinutes(5L));
			return Ok(dto);
		
		
	}

	[HttpPut]
	public async Task<IActionResult> UpdateAddress([FromBody] CreateAddressDTO address)
	{
		_logger.LogInformation("Updating address with ID: {Id}", address.Id);
		
			Address existingAddress = await _unitOfWork.Addresses.GetByIdAsync(address.Id);
			if (existingAddress == null)
			{
				return NotFound();
			}
			_mapper.Map(address, existingAddress);
			_unitOfWork.Addresses.Update(existingAddress);
			await _unitOfWork.CompleteAsync();
			return Ok(existingAddress);
		
		
	}

	[HttpDelete]
	[Route("{id:int}")]
	public async Task<IActionResult> DeleteAddress(int id)
	{
		_logger.LogInformation("Deleting address with ID: {Id}", id);
		
			Address address = await _unitOfWork.Addresses.GetByIdAsync(id);
			if (address == null)
			{
				return NotFound();
			}
			_unitOfWork.Addresses.Delete(address);
			await _unitOfWork.CompleteAsync();
			return NoContent();
	
		
	}
}
