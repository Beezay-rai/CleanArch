using Domain.Common;
using Domain.Entities.ToDo.Events;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ToDo
{
    public sealed class ToDo : BaseEntity
    {
        public ToDo(Guid id) : base(id)
        {

        }

        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime DueDate { get; init; }
        public ToDoStatus Status { get; init; }


        public static ToDo Create(string Name, string Description, DateTime DueDate)
        {
            var todo = new ToDo(Guid.NewGuid())
            {
                Name = Name,
                Description = Description,
                DueDate = DueDate,
                Status =ToDoStatus.NotStarted,
            };
            todo.CreateDomainEvent(new CreateToDoEvent(todo.Id));
            return todo;
        }

    }
}
