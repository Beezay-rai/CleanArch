using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.ToDo.Events
{
    public record CreateToDoEvent(Guid Id):IDomainEvent
    {
       
    }
}
