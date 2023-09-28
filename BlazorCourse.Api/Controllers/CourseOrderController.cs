using BlazorCourse.Business.Contracts;
using BlazorCourse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCourse.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CourseOrderController : Controller
    {
        private readonly ICourseOrderInfoRepository _courseOrderInfoRepository;

        public CourseOrderController(ICourseOrderInfoRepository courseOrderInfoRepository)
        {
            _courseOrderInfoRepository = courseOrderInfoRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PaymentSuccessful([FromBody] CourseOrderInfoDto model)
        {
            var service = new SessionService();
            var sessionDetail = service.Get(model.StripeSessionId);
            if(sessionDetail.PaymentStatus == "paid")
            {
                var result = _courseOrderInfoRepository.PaymentSuccessful(model);
                if (result == null)
                    return BadRequest("İşlem esnasında hata olmuştur.");
                return Ok(result);
            }
            return BadRequest("Ödeme işlemi esnasında hata olmuştur.");
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CourseOrderInfoDto model)
        {
            if(ModelState.IsValid)
            {
                var result = await _courseOrderInfoRepository.Create(model);
                return Ok(result.Data);            
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
