using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    /// <summary>
    /// Query to retrieve a sale by its ID.
    /// </summary>
    public class GetSaleByIdCommand : IRequest<GetSaleByIdResult>
    {
        public Guid Id { get; set; }

        public GetSaleByIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
