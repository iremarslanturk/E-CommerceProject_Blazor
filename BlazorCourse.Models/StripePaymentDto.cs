using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCourse.Models
{
    public class StripePaymentDto
    {
        public string CourseName { get; set; }
        public decimal Amount { get; set; }
        public string ImageUrl { get; set; }
        public string ReturnUrl { get; set; }
    }
}
