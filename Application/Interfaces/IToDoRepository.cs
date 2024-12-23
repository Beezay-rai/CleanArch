using Application.Interfaces.Common;
using Domain.Entities.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IToDoRepository : IGenericRepository<ToDo>
    {

    }

}
