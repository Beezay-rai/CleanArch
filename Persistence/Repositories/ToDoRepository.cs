using Application.Interfaces;
using Domain.Entities.ToDo;
using Persistence.Data;
using Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ToDoRepository : GenericRepository<ToDo>, IToDoRepository
    {
        public ToDoRepository(MyAppDbContext context) : base(context)
        {
        }
    }
}
