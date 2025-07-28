using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for the CreateSaleCommand object.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.SaleNumber).NotEmpty().Length(3, 20);
        RuleFor(x => x.CustomerName).NotEmpty().Length(3, 100);
        RuleFor(x => x.BranchName).NotEmpty().Length(3, 100);
        RuleFor(x => x.SaleDate).LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(x => x.Items).NotNull().NotEmpty();

        RuleForEach(x => x.Items).SetValidator(new CreateSaleItemValidator());
    }
}