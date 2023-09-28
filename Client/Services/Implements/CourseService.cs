using BlazorCourse.Common;
using BlazorCourse.Models;
using Client.Services.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client.Services.Implements
{
    public class CourseService : ICourseService
    {
        private readonly HttpClient _httpClient;

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }

        public async Task<Result<IEnumerable<CourseDto>>> GetAllCourse()
        {
            var response = await _httpClient.GetAsync("https://localhost:44349/api/Course/");
            var content = await response.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<IEnumerable<CourseDto>>(content);
            return new Result<IEnumerable<CourseDto>>(true, ResultConstant.RecordFound, courses);
        }

        public async Task<Result<CourseDto>> GetCourse(int courseId)
        {
            var response = await _httpClient.GetAsync("https://localhost:44349/api/Course/"+courseId);
            var content = await response.Content.ReadAsStringAsync();
            var courses = JsonConvert.DeserializeObject<CourseDto>(content);
            return new Result<CourseDto>(true, ResultConstant.RecordFound, courses);
        }
    }
}
