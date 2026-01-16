namespace EcommerceSystem.Application.DTOS;

public class ProductQueryParameter
{
	private const int MaxPageSize = 50;

	private int _pageSize = 10;

	public int PageNumber { get; set; } = 1;

	public int PageSize
	{
		get
		{
			return _pageSize;
		}
		set
		{
			_pageSize = ((value > 50) ? 50 : value);
		}
	}

	public string? Search { get; set; }

	public int? CategoryId { get; set; }

	public decimal? MinPrice { get; set; }

	public decimal? MaxPrice { get; set; }
}
