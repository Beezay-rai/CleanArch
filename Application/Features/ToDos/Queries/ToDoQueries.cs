using Application.DTOs.ToDo;
using Application.Interfaces;
using AutoMapper;
using Domain.Common;
using LanguageExt.Common;
using MediatR;

namespace Application.Features.ToDos.Queries
{
    public class GetAllToDoCommand : IRequest<Result<IEnumerable<ToDoDTO>>>
    {

    }
    public class GetAllToDoCommandHandler : IRequestHandler<GetAllToDoCommand, Result<IEnumerable<ToDoDTO>>>
    {
        private readonly IToDoRepository _repo;
        private readonly IMapper _mapper;
        public GetAllToDoCommandHandler(IToDoRepository repo, IMapper mapper)
        
        {
            _repo = repo;
            _mapper = mapper;

        }

        public async Task<Result<IEnumerable<ToDoDTO>>> Handle(GetAllToDoCommand request, CancellationToken cancellationToken)
        {
            var data = await _repo.GetAllAsync();


            var random = new Random().Next(1, 3);
            switch (random)
            {
                case 1:
                    return new Result<IEnumerable<ToDoDTO>>(new Exception("Internal  Exception"));
                default:
                    break;

            };
            var res = data.Select(x => new ToDoDTO()
            {
                Id = x.Id,  
                Description = x.Description,
                DueDate = x.DueDate,
            }).ToList();
            
            return res;

        }
    }
}
