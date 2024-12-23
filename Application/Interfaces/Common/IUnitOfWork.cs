using Domain.Entities.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Common
{
    public interface IUnitOfWork
    {
        IToDoRepository ToDoRepository { get; } 

        public int SaveChanges();
    }
}
