using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCourse.Models
{
    public class StripeSuccessfulModel
    {
        public object sessionId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
