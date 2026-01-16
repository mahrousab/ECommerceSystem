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
public class CategoryController : ControllerBase
{
	private readonly ILogger<CategoryController> _logger;

	private readonly IUniteOfWork _uniteOfWork;

	public CategoryController(ILogger<CategoryController> logger, IUniteOfWork uniteOfWork)
	{
		_logger = logger;
		_uniteOfWork = uniteOfWork;
	}

	[HttpGet("GetAll")]
	public IActionResult GetAllCategory()
	{
		_logger.LogInformation("Fetching all categories");
		try
		{
			IEnumerable<Category> categories = _uniteOfWork.Category.GetAll();
			return Ok(categories);
		}
		catch (Exception exception)
		{
			_logger.LogError(exception, "Error occurred while fetching all categories");
			return StatusCode(500, "Internal server error");
		}
	}

	[HttpGet]
	[Route("{id:int}")]
	public async Task<IActionResult> GetById(int id)
	{
		_logger.LogInformation("Fetching category with ID: {Id}", id);
		try
		{
			Category category = await _uniteOfWork.Category.GetByIdAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			return Ok(category);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError(ex2, "Error occurred while fetching category with ID: {Id}", id);
			return StatusCode(500, "Internal server error");
		}
	}

	[HttpPost("AddOne")]
	public async Task<IActionResult> CreateCategory(int id, [FromBody] CategoryDto category)
	{
		_logger.LogInformation("Creating a new category");
		
			if (!base.ModelState.IsValid)
			{
				return BadRequest(base.ModelState);
			}
			Category newCategory = new Category
			{
				Name = category.Name
			};
			await _uniteOfWork.Category.AddAsync(newCategory);
			await _uniteOfWork.CompleteAsync();
			return Ok(newCategory);
		
		
	}

	[HttpPut]
	public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto category)
	{
		_logger.LogInformation("Updating Category");
		try
		{
			if (!base.ModelState.IsValid)
			{
				return BadRequest(base.ModelState);
			}
			Category newCategory = new Category
			{
				Name = category.Name
			};
			_uniteOfWork.Category.Update(newCategory);
			await _uniteOfWork.CompleteAsync();
			return Ok(newCategory);
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError(ex2, "Error occurred while updating category");
			return StatusCode(500, "Internal server error");
		}
	}

	[HttpDelete]
	public async Task<IActionResult> DeleteCategory(int id)
	{
		_logger.LogInformation("Deleting category with ID: {Id}", id);
		try
		{
			Category category = await _uniteOfWork.Category.GetByIdAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			_uniteOfWork.Category.Delete(category);
			await _uniteOfWork.CompleteAsync();
			return Ok();
		}
		catch (Exception ex)
		{
			Exception ex2 = ex;
			_logger.LogError(ex2, "Error occurred while deleting category with ID: {Id}", id);
			return StatusCode(500, "Internal server error");
		}
	}
}
