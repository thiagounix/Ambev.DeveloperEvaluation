using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById;

/// <summary>
/// Validator for GetSaleByIdRequest
/// </summary>
public class GetSaleByIdRequestValidator : AbstractValidator<GetSaleByIdRequest>
{
    public GetSaleByIdRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Sale ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Sale ID must be a valid GUID.");
    }
}