using Application.DTOs.ToDo;
using Application.Features.ToDos.Commands;
using Application.Features.ToDos.Queries;
using LanguageExt;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public   async Task<Results<Ok<IEnumerable< ToDoDTO>>,ProblemHttpResult>> Get()
        {
            var result = await _mediator.Send(new GetAllToDoCommand());

            var response = result.Match<Results<Ok<IEnumerable<ToDoDTO>>, ProblemHttpResult>>(Succ: (data) =>
            {
                return TypedResults.Ok(data);
            },
            (e) =>
            {
                return TypedResults.Problem(new ProblemDetails(){
                    Title = e.GetType().Name,
                    Instance = HttpContext.Request.Method + " " +HttpContext.Request.Path 
                });
            }

            );

            return response;


        }

        [HttpPost]
        public async Task<Results<Ok<Guid>, BadRequest<ProblemDetails>, ProblemHttpResult>> Post(ToDoModel model)
        {

            var result = await _mediator.Send(new CreateToDoCommand()
            {
                model =new CreateToDoDTO()
                {
                    Description=model.description,
                    DueDate=model.due_date,
                    Name=model.name,    
                }
            });


            var response = result.Match((data) =>
            {
                return TypedResults.Ok(data);
            },
            (e) =>
            {
                Results<Ok<Guid>, BadRequest<ProblemDetails>, ProblemHttpResult> a = e switch
                {
                    MyValidationException=> TypedResults.BadRequest( new ProblemDetails()),
                    _=> TypedResults.Problem(new ProblemDetails()
                    {
                        Title = e.GetType().Name,
                        Instance = HttpContext.Request.Method +" " + HttpContext.Request.Path
                    })
                };
                return a;
            }

            );
            return response;
        }
    }
}
