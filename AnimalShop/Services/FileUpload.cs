using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace AnimalShop.Services
{
    //This service handle file upload , It also handles validation of file extension.
    public class FileUpload : IFileUpload
    {
        private readonly ILogger<FileUpload> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment, ILogger<FileUpload> logger)
        {
            _hostEnvironment = webHostEnvironment;
            _logger = logger;

        }

        public async Task UploadFileAsync(IFormFile selectedFile)
        {


            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "Pictures", selectedFile.FileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await selectedFile.CopyToAsync(stream);
                }

            }

            catch (Exception)
            {
                _logger.LogError($"File upload faild ,File Name : {selectedFile.FileName}");
            }

        }
    }
}
