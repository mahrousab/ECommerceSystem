using System;
using System.Collections.Generic;
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
public class PaymentController : ControllerBase
{
	private readonly ILogger<PaymentController> _logger;

	private readonly IUniteOfWork _unitOfWork;

	private readonly IMapper _mapper;

	public PaymentController(ILogger<PaymentController> logger, IMapper mapper, IUniteOfWork uniteOfWork)
	{
		_logger = logger;
		_mapper = mapper;
		_unitOfWork = uniteOfWork;
	}

	[HttpGet]
	[Route("{id:int}")]
	public IActionResult GetPaymentById(int id)
	{
		Payment payment = _unitOfWork.Payments.GetById(id);
		if (payment == null)
		{
			return NotFound();
		}
		PaymentDto dto = _mapper.Map<PaymentDto>(payment);
		return Ok(dto);
	}

	[HttpGet]
	public IActionResult GetAllPayments()
	{
		IEnumerable<Payment> payments = _unitOfWork.Payments.GetAll();
		IEnumerable<PaymentDto> dto = _mapper.Map<IEnumerable<PaymentDto>>(payments);
		return Ok(dto);
	}

	[HttpPost]
	public async Task<IActionResult> CreatePayment([FromBody] PaymentDto paymentDto)
	{
		_logger.LogInformation("Creating a new payment");
		try
		{
			if (!base.ModelState.IsValid)
			{
				return BadRequest(base.ModelState);
			}
			Payment paymentEntity = _mapper.Map<Payment>(paymentDto);
			await _unitOfWork.Payments.AddAsync(paymentEntity);
			await _unitOfWork.CompleteAsync();
			return Ok(paymentEntity);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError(ex2, "Error occurred while creating a new payment");
			throw;
		}
	}

	[HttpPut]
	public async Task<IActionResult> UpdatePayment([FromBody] PaymentDto paymentDto)
	{
		if (!base.ModelState.IsValid)
		{
			return BadRequest(base.ModelState);
		}
		Payment paymentEntity = _mapper.Map<Payment>(paymentDto);
		_unitOfWork.Payments.Update(paymentEntity);
		await _unitOfWork.CompleteAsync();
		return Ok(paymentEntity);
	}

	[HttpDelete]
	public async Task<IActionResult> DeletePayment(int id)
	{
		Payment payment = await _unitOfWork.Payments.GetByIdAsync(id);
		if (payment == null)
		{
			return NotFound();
		}
		_unitOfWork.Payments.Delete(payment);
		await _unitOfWork.CompleteAsync();
		return NoContent();
	}
}
