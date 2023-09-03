using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AnimalShop.Services
{
    public interface IFileUpload
    {

        Task UploadFileAsync(IFormFile selectedFile);
       
    }
}
