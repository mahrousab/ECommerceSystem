using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Application.IRepository;
using EcommerceSystem.Application.DTOS;
using EcommerceSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EcommerceSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
	private readonly IUniteOfWork _unitOfWork;

	private readonly ILogger<OrderController> _logger;

	public OrderController(ILogger<OrderController> logger, IUniteOfWork unitOfWork)
	{
		_logger = logger;
		_unitOfWork = unitOfWork;
	}

	[HttpGet]
	public IActionResult GetAllOrder()
	{
		_logger.LogInformation("Fetching all orders");
		try
		{
			IEnumerable<Order> orders = _unitOfWork.Order.GetAll();
			return Ok(orders);
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Error occurred while fetching all orders");
			return StatusCode(500, "Internal server error");
		}
	}

	[HttpGet]
	[Route("{id:int}")]
	public IActionResult GetOrderById(int id)
	{
		_logger.LogInformation("Fetching order with ID: {Id}", id);
		try
		{
			Order order = _unitOfWork.Order.GetById(id);
			if (order == null)
			{
				return NotFound();
			}
			return Ok(order);
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Error occurred while fetching order with ID: {Id}", id);
			return StatusCode(500, "Internal server error");
		}
	}

	[HttpPost]
	public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
	{
		_logger.LogInformation("Creating a new order");
		try
		{
			if (!base.ModelState.IsValid)
			{
				return BadRequest(base.ModelState);
			}
			Order newOrder = new Order
			{
				TotalPrice = orderDto.TotalPrice
			};
			await _unitOfWork.Order.AddAsync(newOrder);
			await _unitOfWork.CompleteAsync();
			return Ok(newOrder);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError(ex2, "Error occurred while creating a new order");
			return StatusCode(500, "Internal server error");
		}
	}

	[HttpPut]
	public async Task<IActionResult> UpdateOrder([FromBody] OrderDto orderDto)
	{
		if (!base.ModelState.IsValid)
		{
			return BadRequest(base.ModelState);
		}
		Order orderEntity = new Order
		{
			TotalPrice = orderDto.TotalPrice
		};
		_unitOfWork.Order.Update(orderEntity);
		await _unitOfWork.CompleteAsync();
		return Ok(orderEntity);
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteOrder(int id)
	{
		Order order = _unitOfWork.Order.GetById(id);
		if (order == null)
		{
			return NotFound();
		}
		_unitOfWork.Order.Delete(order);
		await _unitOfWork.CompleteAsync();
		return NoContent();
	}
}
