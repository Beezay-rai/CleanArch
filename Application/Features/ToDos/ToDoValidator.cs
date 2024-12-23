using Application.DTOs.ToDo;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ToDos
{
    public class ToDoValidator:AbstractValidator<CreateToDoDTO>
    {
        public ToDoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required !");
            RuleFor(x => x.Description).MaximumLength(50);
            RuleFor(x=>x.DueDate)
                .LessThan(DateTime.UtcNow).WithMessage("Due Date cannot be less than today !");
                
        }
    }
}
