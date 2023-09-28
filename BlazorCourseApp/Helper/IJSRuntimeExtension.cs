using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorCourseApp.Helper
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }
        public static async ValueTask ToasrtError(this IJSRuntime jSRuntime, string message)
        {
            await jSRuntime.InvokeVoidAsync("DisplayToastr", "error", message);
        }
    }
}
