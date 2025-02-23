using Application.Features.Questions.Commands.Create;
using Application.Features.Questions.Commands.Delete;
using Application.Features.Questions.Commands.Update;
using Application.Features.Questions.Queries.GetById;
using Application.Features.Questions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Questions.Queries.GetDynamic;
using NArchitecture.Core.Persistence.Dynamic;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateQuestionCommand createQuestionCommand)
    {
        CreatedQuestionResponse response = await Mediator.Send(createQuestionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateQuestionCommand updateQuestionCommand)
    {
        UpdatedQuestionResponse response = await Mediator.Send(updateQuestionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedQuestionResponse response = await Mediator.Send(new DeleteQuestionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdQuestionResponse response = await Mediator.Send(new GetByIdQuestionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListQuestionQuery getListQuestionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListQuestionListItemDto> response = await Mediator.Send(getListQuestionQuery);
        return Ok(response);
    }
    [HttpPost("Dynamic")]
    public async Task<IActionResult> GetDynamic([FromQuery] PageRequest pageRequest,[FromBody] DynamicQuery dynamicQuery)
    {
        GetDynamicQuestionQuery dynamicQuestionQuery = new() {  DynamicQuery = dynamicQuery ,PageRequest = pageRequest};
        var response = await Mediator.Send(dynamicQuestionQuery);
        return Ok(response);
    }
}