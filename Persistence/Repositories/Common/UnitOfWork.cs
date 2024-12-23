using Application.Interfaces;
using Application.Interfaces.Common;
using Domain.Entities.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        public IToDoRepository ToDoRepository => throw new NotImplementedException();

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
