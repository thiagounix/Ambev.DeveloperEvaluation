using MediatR;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleCommand : IRequest<List<GetSaleResult>>
{
}
