using Client.Services.Contracts;
using Client.Services.Implements;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorCourse.Common;

namespace Client
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(ResultConstant.BaseApiUrl) });
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<ICourseOrderInfoService, CourseOrderInfoService>();
            builder.Services.AddScoped<IStripePaymentService, StripePaymentService>();


            await builder.Build().RunAsync();
        }
    }
}
