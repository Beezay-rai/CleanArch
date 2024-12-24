using Application.DTOs.ToDo;
using Application.Interfaces;
using Application.Interfaces.Common;
using Domain.Common;
using Domain.Entities.ToDo;
using LanguageExt;
using LanguageExt.Common;
using MediatR;

namespace Application.Features.ToDos.Commands
{
    public class CreateToDoCommand : IRequest<Result<Guid>>
    {
        public CreateToDoDTO model { get; init; }
      
    }
    internal class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, Result<Guid>>
    {
        private readonly IToDoRepository _repo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ToDoValidator _validator;
        public CreateToDoCommandHandler(IToDoRepository repo, ToDoValidator validator,IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Guid>> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var check = _validator.Validate(request.model);

            if (!check.IsValid)
            {
                return new Result<Guid>(new MyValidationException("Validation Exception"));
            }
            var random = new Random().Next(1, 2);
            switch (random)
            {
                case 1:
                    return new Result<Guid>(new Exception("Internal  Exception"));
                default:
                    break;

            };

            var entity = ToDo.Create(request.model.Name, request.model.Description, request.model.DueDate);

            await _repo.Add(entity);
             _unitOfWork.SaveChanges();
            return entity.Id;
        }

    }

    public class MyValidationException : Exception
    {
        public MyValidationException(string message) : base(message)
        {
        }
    }


}
