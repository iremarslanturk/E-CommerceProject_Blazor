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
    public class StripePaymentService : IStripePaymentService
    {
        private readonly HttpClient _client;

        public StripePaymentService(HttpClient client)
        {
            _client = client;
        }

        public async Task<StripeSuccessfulModel> Checkout(StripePaymentDto model)
        {
           
            var content = JsonConvert.SerializeObject(model);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://localhost:44349/api/Payment/create", bodyContent);
            var a = response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<StripeSuccessfulModel>(contentTemp);
                return result;
              
            }
            else
            {
                var contentTemp = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<StripeSuccessfulModel>(contentTemp);
                return result;
            }
        }
    }
}
