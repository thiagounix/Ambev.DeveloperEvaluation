using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between CreateSaleCommand and Sale entity.
/// </summary>
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, Sale>();
            CreateMap<SaleItem, Domain.Entities.SaleItem>();
            CreateMap<Sale, CreateSaleResult>();
        }
    }
