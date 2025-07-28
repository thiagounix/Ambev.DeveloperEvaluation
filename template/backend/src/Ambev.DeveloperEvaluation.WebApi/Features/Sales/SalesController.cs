using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSaleById;
using Ambev.DeveloperEvaluation.Application.Sales.GetSaleById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing sale operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SalesController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SalesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetSaleResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSales(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetSaleCommand(), cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a sale by its ID
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSaleByIdResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSaleById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSaleByIdRequest { Id = id };
        var validator = new GetSaleByIdRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var query = new GetSaleByIdCommand(request.Id);
        var result = await _mediator.Send(query, cancellationToken);

        if (result is null)
        {
            return NotFound(new ApiResponse
            {
                Success = false,
                Message = "Sale not found"
            });
        }

        var response = _mapper.Map<GetSaleByIdResponse>(result);

        return Ok(new ApiResponseWithData<GetSaleByIdResponse>
        {
            Success = true,
            Message = "Sale retrieved successfully",
            Data = response
        });
    }

    /// <summary>
    /// Creates a new sale
    /// </summary>
    /// <param name="command">The sale creation command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the created sale</returns>
    [HttpPost]
    [ProducesResponseType(typeof(CreateSaleResult), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(Create), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(typeof(UpdateSaleResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateSaleCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest("Path ID does not match body ID.");

        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }
   
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteSaleCommand(id), cancellationToken);
        return NoContent();
    }

}