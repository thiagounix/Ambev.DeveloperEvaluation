
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSaleById
{
    /// <summary>
    /// Handles the GetSaleById query.
    /// </summary>
    public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdCommand, GetSaleByIdResult?>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        public GetSaleByIdHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        public async Task<GetSaleByIdResult?> Handle(GetSaleByIdCommand request, CancellationToken cancellationToken)
        {
            var validator = new GetSaleByIdValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            
            var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);

            if (sale == null)
                return null;

            return _mapper.Map<GetSaleByIdResult>(sale);
        }
    }
}
