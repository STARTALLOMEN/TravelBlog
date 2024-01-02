using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;

namespace API.Services
{
    public interface IImageShareService
    {
        List<ImageShare>? GetAllImageShare();
        ImageShare? GetImageShareById(int id);
        List<ImageShare>? GetImageSharesByName(string name);
        ImageShare? GetImageShareByName(string name);
        List<ImageShareDto>? GetImageSharesOfDestination(int desId);
        void CreateImageShare(ImageShareAdd ImageShare, string username);
    }
}