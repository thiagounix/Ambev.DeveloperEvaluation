using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Validates the rules for the Sale entity.
/// </summary>
public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty().WithMessage("Sale number is required.")
            .MinimumLength(3).WithMessage("Sale number must be at least 3 characters.")
            .MaximumLength(20).WithMessage("Sale number cannot exceed 20 characters.");

        RuleFor(sale => sale.CustomerName)
            .NotEmpty().WithMessage("Customer name is required.")
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(sale => sale.BranchName)
            .NotEmpty().WithMessage("Branch name is required.")
            .MinimumLength(3)
            .MaximumLength(100);

        RuleFor(sale => sale.SaleDate)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Sale date cannot be in the future.");

        RuleFor(sale => sale.Items)
            .NotNull()
            .NotEmpty().WithMessage("At least one sale item is required.");

        RuleForEach(sale => sale.Items)
            .SetValidator(new SaleItemValidator());
    }
}