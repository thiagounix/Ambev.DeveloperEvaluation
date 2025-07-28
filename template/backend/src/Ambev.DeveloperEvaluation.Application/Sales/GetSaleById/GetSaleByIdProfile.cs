using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    /// <summary>
    /// AutoMapper profile to map Sale to GetSaleByIdResult.
    /// </summary>
    public class GetSaleByIdProfile : Profile
    {
        public GetSaleByIdProfile()
        {
            CreateMap<Sale, GetSaleByIdResult>();
            CreateMap<SaleItem, GetSaleItemResult>();
        }
    }
}