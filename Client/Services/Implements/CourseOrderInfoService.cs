﻿using BlazorCourse.Common;
using BlazorCourse.Models;
using Client.Services.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services.Implements
{
    public class CourseOrderInfoService : ICourseOrderInfoService
    {
        private readonly HttpClient _httpClient;

        public CourseOrderInfoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<CourseOrderInfoDto>> PaymentSuccessful(CourseOrderInfoDto model)
        {
            var content = JsonConvert.SerializeObject(model);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44349/api/CourseOrder/PaymentSuccessful", bodyContent);
           
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<CourseOrderInfoDto>(data);
                return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordFound, result);
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                return new Result<CourseOrderInfoDto>(false, ResultConstant.RecordNotFound);
            }
        }

        public async Task<Result<CourseOrderInfoDto>> SaveCourseOrderInfo(CourseOrderInfoDto model)
        {
            var content = JsonConvert.SerializeObject(model);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/courseOrder/create", bodyContent);
            string res = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<CourseOrderInfoDto>(data);
                return new Result<CourseOrderInfoDto>(true, ResultConstant.RecordFound, result);
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                return new Result<CourseOrderInfoDto>(false, ResultConstant.RecordNotFound);
            }
        }
    }
}
