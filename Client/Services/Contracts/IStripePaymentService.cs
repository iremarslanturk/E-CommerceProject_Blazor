using BlazorCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Services.Contracts
{
    public interface IStripePaymentService
    {
        public Task<StripeSuccessfulModel> Checkout(StripePaymentDto model);
    }
}
