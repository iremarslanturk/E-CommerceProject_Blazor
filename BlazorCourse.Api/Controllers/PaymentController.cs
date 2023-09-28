using BlazorCourse.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCourse.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;

        public PaymentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]StripePaymentDto model)
        {
            try
            {
                var domain = _configuration.GetValue<string>("BlazorCourse_Client_URL");

                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string>
                    {
                        "card"
                    },
                    LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                UnitAmount = 12 * 100,
                                Currency = "usd",
                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = model.CourseName
                                }
                            },
                            Quantity = 1
                        }
                    },
                    Mode = "payment",
                    SuccessUrl = domain + "success-payment?session_id={{CHECKOUT_SESSION_ID}}",
                    CancelUrl = domain + model.ReturnUrl
                };

                var service = new SessionService();
                var session = await service.CreateAsync(options);

                return Ok(new StripeSuccessfulModel { sessionId = session.Id });
            }

            catch (System.Exception ex)
            {

                return BadRequest(new StripeSuccessfulModel { sessionId = ex.Message.ToString() });
            }
      
        }
    }
}
