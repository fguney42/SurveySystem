using Application.Features.ParticipationResults.Commands.Create;
using Application.Features.ParticipationResults.Commands.Delete;
using Application.Features.ParticipationResults.Commands.Update;
using Application.Features.ParticipationResults.Queries.GetById;
using Application.Features.ParticipationResults.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ParticipationResultsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateParticipationResultCommand createParticipationResultCommand)
    {
        CreatedParticipationResultResponse response = await Mediator.Send(createParticipationResultCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateParticipationResultCommand updateParticipationResultCommand)
    {
        UpdatedParticipationResultResponse response = await Mediator.Send(updateParticipationResultCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedParticipationResultResponse response = await Mediator.Send(new DeleteParticipationResultCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdParticipationResultResponse response = await Mediator.Send(new GetByIdParticipationResultQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListParticipationResultQuery getListParticipationResultQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListParticipationResultListItemDto> response = await Mediator.Send(getListParticipationResultQuery);
        return Ok(response);
    }
}