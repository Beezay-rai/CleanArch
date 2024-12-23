using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ToDo
{

    public class ToDoDTO
    {
        public Guid Id { get; set; }
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime DueDate { get; init; }
    }

    public class CreateToDoDTO
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public DateTime DueDate { get; init; }
    }
}
