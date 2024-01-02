using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Repositories
{
    public interface ILocationRepository
    {
        List<Province>? GetAllProvince();
        // List<Dictrict>? GetDictrictByProvinceId(int id);
        // List<Ward>? GetWardByDictrictId(int id);
        bool SaveChanges();
    }
}