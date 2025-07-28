namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById;

/// <summary>
/// Represents the incoming request to retrieve a Sale by ID
/// </summary>
public class GetSaleByIdRequest
{
    public Guid Id { get; set; }
}