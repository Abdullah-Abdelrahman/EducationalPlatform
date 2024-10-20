using EducationalPlatform.Service.Abstracts;
using Microsoft.AspNetCore.Http;
//these 2 libarariys are for working with an file 

namespace EducationalPlatform.Service.Implementations
{
    public class FileUploadService : IFileUploadService
    {

        //Create an file for the image and creat an uniqe name for it
        public async Task<string> UploadFile(IFormFile? file, string WebRootPath)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(WebRootPath, "Files");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
