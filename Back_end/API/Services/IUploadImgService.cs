using Microsoft.AspNetCore.Http;

namespace API.Services
{
    public interface IUploadImgService
    {
        Task<string> UploadImage(string folder,string username,IFormFile model);
    }
}