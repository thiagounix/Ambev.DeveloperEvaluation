using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleItemValidator : AbstractValidator<UpdateSaleItem>
    {
        public UpdateSaleItemValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Quantity).InclusiveBetween(1, 20);
            RuleFor(x => x.UnitPrice).GreaterThan(0);
        }
    }
}
