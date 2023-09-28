using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;

namespace BlazorCourseApp.Service
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
    }
}
