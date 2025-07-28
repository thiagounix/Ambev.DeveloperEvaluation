using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Request to delete a sale by ID.
/// </summary>
public class DeleteSaleRequest : IRequest
{
    public Guid Id { get; set; }

    public DeleteSaleRequest(Guid id)
    {
        Id = id;
    }
}