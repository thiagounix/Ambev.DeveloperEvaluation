using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleValidator()
    {
        RuleFor(x => x.SaleNumber)
            .NotEmpty().WithMessage("SaleNumber is required.");

        RuleFor(x => x.CustomerName)
            .NotEmpty().WithMessage("CustomerName is required.");

        RuleFor(x => x.BranchName)
            .NotEmpty().WithMessage("BranchName is required.");

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("At least one item must be included in the sale.")
            .Must(x => x.Count <= 100).WithMessage("Too many items in a single sale.");

        RuleForEach(x => x.Items).SetValidator(new SaleItemValidator());
    }
}