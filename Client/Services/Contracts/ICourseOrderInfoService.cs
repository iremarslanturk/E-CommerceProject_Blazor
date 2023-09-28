using BlazorCourse.Common;
using BlazorCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services.Contracts
{
    public interface ICourseOrderInfoService
    {
        public Task<Result<CourseOrderInfoDto>> SaveCourseOrderInfo(CourseOrderInfoDto model);
        public Task<Result<CourseOrderInfoDto>> PaymentSuccessful(CourseOrderInfoDto model);
    }
} 
