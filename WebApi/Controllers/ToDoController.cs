using Application.DTOs.ToDo;
using Application.Features.ToDos.Commands;
using Application.Features.ToDos.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/v1/toDo")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IResult>Get()
        {
            var result =await _mediator.Send(new GetAllToDoCommand());

            return result.Match(
                Results.Ok,
                error => Results.BadRequest(error.description));
        }

        [HttpPost]
        public async Task<IResult>Post(ToDoModel model)
        {
            var result = await _mediator.Send(new CreateToDoCommand());
            return result.Match(
                Results.Ok,
                error =>
                {
                    var myresult = error switch
                    {
                        ToDoValidationError =>Results.BadRequest(error.description),
                        _ => Results.StatusCode(500)
                    };

                    return myresult;
                });

        }
    }
}
