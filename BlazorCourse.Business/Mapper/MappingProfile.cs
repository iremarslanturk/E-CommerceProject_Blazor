using AutoMapper;
using BlazorCourse.Common;
using BlazorCourse.DataAccess.Data;
using BlazorCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCourse.Business.Mapper
{
  
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CourseDto, Course>().ReverseMap()
                .ForMember(c=> c.ImageUrl, o=>o.MapFrom<CourseItemUrlResolver>());

            CreateMap<CourseOrderInfo, CourseOrderInfoDto>().ReverseMap();
        }
    }
}
