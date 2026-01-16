using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ecommerce.Application.IRepository;
using EcommerceSystem.Application.DTOS;
using EcommerceSystem.Domain.Models;
using EcommerceSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private readonly ECommerceSystemDbContext _eCommerceDbContext;

	public GenericRepository(ECommerceSystemDbContext eCommerceDbContext)
	{
		_eCommerceDbContext = eCommerceDbContext;
	}

	public IEnumerable<T> GetAll()
	{
		return _eCommerceDbContext.Set<T>().ToList();
	}

	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _eCommerceDbContext.Set<T>().ToListAsync();
	}

	public T GetById(int id)
	{
		return _eCommerceDbContext.Set<T>().Find(id);
	}

	public async Task<T> GetByIdAsync(int id)
	{
		return await _eCommerceDbContext.Set<T>().FindAsync(id);
	}

	public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
	{
		IQueryable<T> query = _eCommerceDbContext.Set<T>();
		if (includes != null)
		{
			foreach (string incluse in includes)
			{
				query = query.Include(incluse);
			}
		}
		return query.SingleOrDefault(criteria);
	}

	public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
	{
		IQueryable<T> query = _eCommerceDbContext.Set<T>();
		if (includes != null)
		{
			foreach (string incluse in includes)
			{
				query = query.Include(incluse);
			}
		}
		return await query.SingleOrDefaultAsync(criteria);
	}

	public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
	{
		IQueryable<T> query = _eCommerceDbContext.Set<T>();
		if (includes != null)
		{
			foreach (string include in includes)
			{
				query = query.Include(include);
			}
		}
		return query.Where(criteria).ToList();
	}

	public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take)
	{
		return _eCommerceDbContext.Set<T>().Where(criteria).Skip(skip)
			.Take(take)
			.ToList();
	}

	public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
	{
		IQueryable<T> query = _eCommerceDbContext.Set<T>().Where(criteria);
		if (skip.HasValue)
		{
			query = query.Skip(skip.Value);
		}
		if (take.HasValue)
		{
			query = query.Take(take.Value);
		}
		if (orderBy != null)
		{
			query = ((!(orderByDirection == "ASC")) ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy));
		}
		return query.ToList();
	}

	public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
	{
		IQueryable<T> query = _eCommerceDbContext.Set<T>();
		if (includes != null)
		{
			foreach (string include in includes)
			{
				query = query.Include(include);
			}
		}
		return await query.Where(criteria).ToListAsync();
	}

	public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
	{
		return await _eCommerceDbContext.Set<T>().Where(criteria).Skip(skip)
			.Take(take)
			.ToListAsync();
	}

	public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
	{
		IQueryable<T> query = _eCommerceDbContext.Set<T>().Where(criteria);
		if (take.HasValue)
		{
			query = query.Take(take.Value);
		}
		if (skip.HasValue)
		{
			query = query.Skip(skip.Value);
		}
		if (orderBy != null)
		{
			query = ((!(orderByDirection == "ASC")) ? query.OrderByDescending(orderBy) : query.OrderBy(orderBy));
		}
		return await query.ToListAsync();
	}

	public T Add(T entity)
	{
		_eCommerceDbContext.Set<T>().Add(entity);
		return entity;
	}

	public async Task<T> AddAsync(T entity)
	{
		await _eCommerceDbContext.Set<T>().AddAsync(entity);
		return entity;
	}

	public IEnumerable<T> AddRange(IEnumerable<T> entities)
	{
		_eCommerceDbContext.Set<T>().AddRange(entities);
		return entities;
	}

	public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
	{
		await _eCommerceDbContext.Set<T>().AddRangeAsync(entities);
		return entities;
	}

	public T Update(T entity)
	{
		_eCommerceDbContext.Update(entity);
		return entity;
	}

	public void Delete(T entity)
	{
		_eCommerceDbContext.Set<T>().Remove(entity);
	}

	public void DeleteRange(IEnumerable<T> entities)
	{
		_eCommerceDbContext.Set<T>().RemoveRange(entities);
	}

	public void Attach(T entity)
	{
		_eCommerceDbContext.Set<T>().Attach(entity);
	}

	public void AttachRange(IEnumerable<T> entities)
	{
		_eCommerceDbContext.Set<T>().AttachRange(entities);
	}

	public int Count()
	{
		return _eCommerceDbContext.Set<T>().Count();
	}

	public int Count(Expression<Func<T, bool>> criteria)
	{
		return _eCommerceDbContext.Set<T>().Count(criteria);
	}

	public async Task<int> CountAsync()
	{
		return await _eCommerceDbContext.Set<T>().CountAsync();
	}

	public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
	{
		return await _eCommerceDbContext.Set<T>().CountAsync(criteria);
	}

	public async Task<PageResult<Product>> GetProductsAsync(ProductQueryParameter query)
	{
		IQueryable<Product> products = _eCommerceDbContext.Products.AsQueryable();
		if (!string.IsNullOrWhiteSpace(query.Search))
		{
			products = products.Where((Product p) => p.Name.Contains(query.Search) || p.Description.Contains(query.Search));
		}
		if (query.CategoryId.HasValue)
		{
			products = products.Where((Product p) => (int?)p.CategoryId == query.CategoryId);
		}
		if (query.MinPrice.HasValue)
		{
			products = products.Where((Product p) => (decimal?)p.Price >= query.MinPrice);
		}
		if (query.MaxPrice.HasValue)
		{
			products = products.Where((Product p) => (decimal?)p.Price <= query.MaxPrice);
		}
		return new PageResult<Product>(totalCount: await products.CountAsync(), items: await products.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToListAsync(), pageNumber: query.PageNumber, pageSize: query.PageSize);
	}
}
