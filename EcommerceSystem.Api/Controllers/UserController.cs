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
public class UserController : ControllerBase
{
	private readonly ILogger<UserController> _logger;

	private readonly IUniteOfWork _unitOfWork;

	private readonly IMapper _mapper;

	public UserController(ILogger<UserController> logger, IUniteOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
		_logger = logger;
	}

	[HttpGet]
	[Route("{id:int}")]
	public IActionResult GetUserById(int id)
	{
		User user = _unitOfWork.Users.GetById(id);
		if (user == null)
		{
			return NotFound();
		}
		UserDto dto = _mapper.Map<UserDto>(user);
		return Ok(dto);
	}

	[HttpGet]
	public IActionResult GetAllUsers()
	{
		IEnumerable<User> users = _unitOfWork.Users.GetAll();
		IEnumerable<UserDto> dto = _mapper.Map<IEnumerable<UserDto>>(users);
		return Ok(dto);
	}

	[HttpPost]
	public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
	{
		_logger.LogInformation("Creating a new user");
		try
		{
			if (!base.ModelState.IsValid)
			{
				return BadRequest(base.ModelState);
			}
			User userEntity = _mapper.Map<User>(userDto);
			await _unitOfWork.Users.AddAsync(userEntity);
			await _unitOfWork.CompleteAsync();
			return Ok(userEntity);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError(ex2, "Error occurred while creating a new user");
			throw;
		}
	}

	[HttpPut]
	public async Task<IActionResult> UpdateUser([FromBody] UserDto userDto)
	{
		_logger.LogInformation("Updating a user");
		try
		{
			if (!base.ModelState.IsValid)
			{
				return BadRequest(base.ModelState);
			}
			User userEntity = _mapper.Map<User>(userDto);
			_unitOfWork.Users.Update(userEntity);
			await _unitOfWork.CompleteAsync();
			return Ok(userEntity);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError(ex2, "Error occurred while updating a user");
			throw;
		}
	}

	[HttpDelete]
	[Route("{id:int}")]
	public async Task<IActionResult> DeleteUser(int id)
	{
		User user = await _unitOfWork.Users.GetByIdAsync(id);
		if (user == null)
		{
			return NotFound();
		}
		_unitOfWork.Users.Delete(user);
		await _unitOfWork.CompleteAsync();
		return NoContent();
	}
}
