using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{

    public class SaleItemValidator : AbstractValidator<SaleItemRequest>
    {
        public SaleItemValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("ProductName is required.");

            RuleFor(x => x.Quantity)
                .InclusiveBetween(1, 20).WithMessage("Quantity must be between 1 and 20.");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("UnitPrice must be greater than 0.");
        }
    }

}
