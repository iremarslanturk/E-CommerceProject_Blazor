using BlazorCourse.Common;
using BlazorCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services.Contracts
{
    public interface ICourseService
    {
        public Task<Result<IEnumerable<CourseDto>>> GetAllCourse();

        public Task<Result<CourseDto>> GetCourse(int courseId);
    }
}
