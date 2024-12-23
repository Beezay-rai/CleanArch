using Application.DTOs.ToDo;
using Application.Interfaces.Common;
using Domain.Common;
using Domain.Entities.ToDo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ToDos.Commands
{
    public class CreateToDoCommand : IRequest<Result<Guid>>
    {
        public CreateToDoDTO model { get; init; }
      
    }
    internal class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ToDoValidator _validator;
        public CreateToDoCommandHandler(IUnitOfWork unitOfWork, ToDoValidator validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<Result<Guid>> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var check = _validator.Validate(request.model);

            if (!check.IsValid)
            {
                return Result<Guid>.Failure(new ToDoValidationError());
            }

            var entity = ToDo.Create(request.model.Name, request.model.Description, request.model.DueDate);

            await _unitOfWork.ToDoRepository.Add(entity);
             _unitOfWork.SaveChanges();
            throw new NotImplementedException();
        }
    }

    public record ToDoValidationError() : Error("","")
    {
       
    }
}
