using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;


public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
{
    public DeleteSaleRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
