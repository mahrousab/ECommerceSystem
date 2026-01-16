using AutoMapper;
using EcommerceSystem.Domain.Models;

namespace EcommerceSystem.Application.DTOS;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Address, AddressDTO>().ForMember((AddressDTO d) => d.Id, delegate(IMemberConfigurationExpression<Address, AddressDTO, int> opt)
		{
			opt.Ignore();
		}).ForMember((AddressDTO d) => d.Id, delegate(IMemberConfigurationExpression<Address, AddressDTO, int> opt)
		{
			opt.MapFrom((Address src) => src.UserId);
		}).ForMember((AddressDTO dest) => dest.Country, delegate(IMemberConfigurationExpression<Address, AddressDTO, string> opt)
		{
			opt.MapFrom((Address src) => src.Country);
		})
			.ForMember((AddressDTO dest) => dest.City, delegate(IMemberConfigurationExpression<Address, AddressDTO, string> opt)
			{
				opt.MapFrom((Address src) => src.City);
			})
			.ForMember((AddressDTO dest) => dest.Street, delegate(IMemberConfigurationExpression<Address, AddressDTO, string> opt)
			{
				opt.MapFrom((Address src) => src.Street);
			})
			.ForMember((AddressDTO dest) => dest.PostalCode, delegate(IMemberConfigurationExpression<Address, AddressDTO, string> opt)
			{
				opt.MapFrom((Address src) => src.PostalCode);
			});
		CreateMap<OrderItem, OrderItemDto>().ForMember((OrderItemDto dest) => dest.Quantity, delegate(IMemberConfigurationExpression<OrderItem, OrderItemDto, int> opt)
		{
			opt.MapFrom((OrderItem src) => src.Quantity);
		}).ForMember((OrderItemDto dest) => dest.Price, delegate(IMemberConfigurationExpression<OrderItem, OrderItemDto, decimal> opt)
		{
			opt.MapFrom((OrderItem src) => src.Price);
		});
		CreateMap<Payment, PaymentDto>().ForMember((PaymentDto dest) => dest.PaymentStatus, delegate(IMemberConfigurationExpression<Payment, PaymentDto, string> opt)
		{
			opt.MapFrom((Payment src) => src.PaymentStatus);
		}).ForMember((PaymentDto dest) => dest.PaymentMethod, delegate(IMemberConfigurationExpression<Payment, PaymentDto, string> opt)
		{
			opt.MapFrom((Payment src) => src.PaymentMethod);
		});
		CreateMap<User, UserDto>().ForMember((UserDto dest) => dest.Phone, delegate(IMemberConfigurationExpression<User, UserDto, string> opt)
		{
			opt.MapFrom((User src) => src.Phone);
		}).ForMember((UserDto dest) => dest.Name, delegate(IMemberConfigurationExpression<User, UserDto, string> opt)
		{
			opt.MapFrom((User src) => src.Name);
		}).ForMember((UserDto dest) => dest.Email, delegate(IMemberConfigurationExpression<User, UserDto, string> opt)
		{
			opt.MapFrom((User src) => src.Email);
		});
		CreateMap<Product, ProductDto>().ForMember((ProductDto dest) => dest.Name, delegate(IMemberConfigurationExpression<Product, ProductDto, string> opt)
		{
			opt.MapFrom((Product src) => src.Name);
		}).ForMember((ProductDto dest) => dest.Description, delegate(IMemberConfigurationExpression<Product, ProductDto, string> opt)
		{
			opt.MapFrom((Product src) => src.Description);
		}).ForMember((ProductDto dest) => dest.Price, delegate(IMemberConfigurationExpression<Product, ProductDto, decimal> opt)
		{
			opt.MapFrom((Product src) => src.Price);
		});
		CreateMap<CreateAddressDTO, Address>().ForMember((Address d) => d.Id, delegate(IMemberConfigurationExpression<CreateAddressDTO, Address, int> opt)
		{
			opt.Ignore();
		});
		CreateMap<OrderItemDto, OrderItem>();
		CreateMap<PaymentDto, Payment>();
		CreateMap<UserDto, User>();
		CreateMap<ProductDto, Product>();
		CreateMap<CreateAddressDTO, Address>().ReverseMap();
		CreateMap<OrderItemDto, OrderItem>().ReverseMap();
		CreateMap<PaymentDto, Payment>().ReverseMap();
		CreateMap<UserDto, User>().ReverseMap();
		CreateMap<ProductDto, Product>();
	}
}
