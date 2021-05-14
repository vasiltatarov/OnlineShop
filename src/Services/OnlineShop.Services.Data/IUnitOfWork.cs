namespace OnlineShop.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IUnitOfWork
    {
        Task UploadImage(IFormFile file);
    }
}
