using Application.DTOs.ToDo;
using AutoMapper;
using Domain.Entities.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDoDTO,ToDo>().ReverseMap();
            CreateMap<IEnumerable<ToDoDTO>, IEnumerable<ToDo>>().ReverseMap();
        }

    }
}
