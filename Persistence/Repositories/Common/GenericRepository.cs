using Application.Interfaces.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Common
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyAppDbContext _context;

        public GenericRepository(MyAppDbContext context)
        {
            _context = context; 
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task Delete(Guid Id)
        {
            var entity = await GetById(Id);
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid Id)
        {
            var entity = await _context.Set<T>().FindAsync(Id);
            if(entity  == null)
            {
                throw new Exception($" {typeof(T).Name} not found with Id : {Id}");
            }
            return entity;
        }

        public  Task Update(T entity)
        {
             _context .Update(entity);
            return Task.CompletedTask;
        }
    }
}
