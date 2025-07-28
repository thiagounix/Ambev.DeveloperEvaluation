using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Profile for mapping DeleteUser feature requests to commands
/// </summary>
public class DeleteSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteUser feature
    /// </summary>
    public DeleteSaleProfile()
    {
        CreateMap<Guid, Application.Sales.DeleteSale.DeleteSaleRequest>()
            .ConstructUsing(id => new Application.Sales.DeleteSale.DeleteSaleRequest(id));
    }
}