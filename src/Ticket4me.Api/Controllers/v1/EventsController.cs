using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ticket4me.Api.ApiModels.v1.Response;
using Ticket4me.Application.UseCases.v1.Category.ListEvents;
using Ticket4me.Application.UseCases.v1.Event.Common;
using Ticket4me.Application.UseCases.v1.Event.CreateEvent;
using Ticket4me.Application.UseCases.v1.Event.ListEvents;
using Ticket4me.Domain.Searchable;

namespace Ticket4me.Api.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EventsController : ControllerBase
{
    private readonly IMediator _mediator;

    public EventsController(IMediator mediator)
        => _mediator = mediator;

    [HttpPost]
    [ProducesResponseType(typeof(ApiResponse<EventModelOutput>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    public async Task<IActionResult> Create(
        [FromBody] CreateEventInput input,
        CancellationToken cancellationToken
    )
    {
        var output = await _mediator.Send(input, cancellationToken);
        return CreatedAtAction(
            nameof(Create),
            new { output.Id },
            new ApiResponse<EventModelOutput>(output)
        );
    }

    [HttpGet]
    [ProducesResponseType(typeof(ListEventsOutput), StatusCodes.Status200OK)]
    public async Task<IActionResult> List(
        CancellationToken cancellationToken,
        [FromQuery] int? page = null,
        [FromQuery(Name = "per_page")] int? perPage = null,
        [FromQuery] string? search = null,
        [FromQuery] string? sort = null,
        [FromQuery] SearchOrder? dir = null
    )
    {
        var input = new ListEventsInput();
        if (page is not null) input.Page = page.Value;
        if (perPage is not null) input.PerPage = perPage.Value;
        if (!String.IsNullOrWhiteSpace(search)) input.Search = search;
        if (!String.IsNullOrWhiteSpace(sort)) input.Sort = sort;
        if (dir is not null) input.Dir = dir.Value;

        var output = await _mediator.Send(input, cancellationToken);
        return Ok(
            new ApiResponseList<EventModelOutput>(output)
        );
    }
}
