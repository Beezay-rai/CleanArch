using Application.Interfaces;
using Domain.Common;
using Domain.Entities.ToDo;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyAppDbContext _context;
        private readonly IToDoRepository _toDoRepo;
        public UnitOfWork(MyAppDbContext context ,IToDoRepository todoRepo ) 
        {
            _context = context;
            _toDoRepo = todoRepo;
        }
        public IToDoRepository ToDoRepository => _toDoRepo;

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
