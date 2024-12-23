using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Common
{
    public interface IGenericRepository<T>  where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(Guid Id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(Guid Id);

    }
}
