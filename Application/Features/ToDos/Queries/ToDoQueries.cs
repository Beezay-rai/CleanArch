using Application.DTOs.ToDo;
using Application.Interfaces.Common;
using AutoMapper;
using Domain.Common;
using MediatR;

namespace Application.Features.ToDos.Queries
{
    public class GetAllToDoCommand : IRequest<Result<ToDoDTO>>
    {

    }
    public class GetAllToDoCommandHandler : IRequestHandler<GetAllToDoCommand, Result<ToDoDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllToDoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<Result<ToDoDTO>> Handle(GetAllToDoCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.ToDoRepository.GetAllAsync();
            var res = _mapper.Map<ToDoDTO>(data);
            return res;

        }
    }
}
