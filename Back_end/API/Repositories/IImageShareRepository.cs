using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Repositories
{
    public interface IImageShareRepository
    {
        List<ImageShare>? GetAllImageShare();
        ImageShare? GetImageShareById(int id);
        List<ImageShare>? GetImageSharesByName(string name);
        ImageShare? GetImageShareByName(string name);
        // List<ImageShare>? GetImageSharePopular();
        void CreateImageShare(ImageShare ImageShare);
        void CreateImageShareDetail(ImageShareDetail ImageShare);
        void CreateImageShareDes(ImageShareDestination ImageShare);
        bool SaveChanges();
        ImageShare? GetLastImageShareByUserId(int userId);
        // void CreateImageShareDestination(int imageShareId, List<int> desId);

    }
}