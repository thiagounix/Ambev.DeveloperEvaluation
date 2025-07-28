using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;

    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingSale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
        if (existingSale == null)
            throw new InvalidOperationException($"Sale with ID {command.Id} not found.");

        // Atualiza os dados básicos
        existingSale.SaleNumber = command.SaleNumber;
        existingSale.SaleDate = command.SaleDate;
        existingSale.CustomerName = command.CustomerName;
        existingSale.BranchName = command.BranchName;
        existingSale.IsCancelled = command.IsCancelled;

        // Atualiza os itens (sobrescreve a lista de itens atual)
        existingSale.Items = command.Items.Select(i => new SaleItem
        {
            Id = i.Id,
            ProductName = i.ProductName,
            Quantity = i.Quantity,
            UnitPrice = i.UnitPrice
        }).ToList();

        // Recalcula os valores
        existingSale.TotalAmount = existingSale.Items.Sum(x => x.TotalAmount);
        var totalDiscount = existingSale.Items.Sum(x => x.Discount);

        await _saleRepository.UpdateAsync(existingSale, cancellationToken);

        var result = _mapper.Map<UpdateSaleResult>(existingSale);
        result.Discount = totalDiscount;
        return result;
    }
}