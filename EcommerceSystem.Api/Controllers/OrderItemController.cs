using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Application.IRepository;
using EcommerceSystem.Application.DTOS;
using EcommerceSystem.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EcommerceSystem.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemController : ControllerBase
{
	private readonly ILogger<OrderItemController> _logger;

	private readonly IUniteOfWork _unitOfWork;

	private readonly IMapper _mapper;

	public OrderItemController(ILogger<OrderItemController> logger, IUniteOfWork unitOfWork, IMapper mapper)
	{
		_logger = logger;
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	[HttpGet]
	[Route("{id:int}")]
	public IActionResult GetOrderItemById(int id)
	{
		OrderItem orderItem = _unitOfWork.OrderItem.GetById(id);
		if (orderItem == null)
		{
			return NotFound();
		}
		OrderItemDto dto = _mapper.Map<OrderItemDto>(orderItem);
		return Ok(dto);
	}

	[HttpPost]
	public async Task<IActionResult> CreateOrderItem([FromBody] OrderItemDto orderItemDto)
	{
		if (!base.ModelState.IsValid)
		{
			return BadRequest(base.ModelState);
		}
		OrderItem orderItemEntity = _mapper.Map<OrderItem>(orderItemDto);
		await _unitOfWork.OrderItem.AddAsync(orderItemEntity);
		await _unitOfWork.CompleteAsync();
		return CreatedAtAction("GetOrderItemById", new
		{
			id = orderItemEntity.Id
		}, orderItemEntity);
	}

	[HttpPut]
	public async Task<IActionResult> UpdateOrderItem([FromBody] OrderItemDto orderItemDto)
	{
		if (!base.ModelState.IsValid)
		{
			return BadRequest(base.ModelState);
		}
		OrderItem orderItemEntity = _mapper.Map<OrderItem>(orderItemDto);
		_unitOfWork.OrderItem.Update(orderItemEntity);
		await _unitOfWork.CompleteAsync();
		return Ok(orderItemEntity);
	}

	[HttpDelete]
	[Route("{id:int}")]
	public async Task<IActionResult> DeleteOrderItem(int id)
	{
		OrderItem orderItem = await _unitOfWork.OrderItem.GetByIdAsync(id);
		if (orderItem == null)
		{
			return NotFound();
		}
		_unitOfWork.OrderItem.Delete(orderItem);
		await _unitOfWork.CompleteAsync();
		return NoContent();
	}
}
