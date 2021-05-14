namespace OnlineShop.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;

    public class UnitOfWork : IUnitOfWork
    {
        private IHostEnvironment hostingEnvironment;

        public UnitOfWork(IHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task UploadImage(IFormFile file)
        {
            var totalBytes = file.Length;
            var fileName = file.FileName.Trim('"');
            fileName = this.EnsureFileName(fileName);
            var buffer = new byte[16 * 1024];

            using (FileStream output = File.Create(this.GetPathAndFileName(fileName)))
            {
                using (Stream input = file.OpenReadStream())
                {
                    int readBytes;
                    while ((readBytes = await input.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await output.WriteAsync(buffer, 0, readBytes);
                        totalBytes += readBytes;
                    }
                }
            }
        }

        private string GetPathAndFileName(string fileName)
        {
            var path = this.hostingEnvironment.ContentRootPath + "\\wwwroot\\images\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path + fileName;
        }

        private string EnsureFileName(string fileName)
        {
            if (fileName.Contains("\\"))
            {
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            }

            return fileName;
        }
    }
}
