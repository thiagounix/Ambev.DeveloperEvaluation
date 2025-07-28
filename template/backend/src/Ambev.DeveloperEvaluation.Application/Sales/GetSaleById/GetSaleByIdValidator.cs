using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    /// <summary>
    /// Validator for GetSaleByIdQuery.
    /// </summary>
    public class GetSaleByIdValidator : AbstractValidator<GetSaleByIdCommand>
    {
        public GetSaleByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Sale Id is required.");
        }
    }
}