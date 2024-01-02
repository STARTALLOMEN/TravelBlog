using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;

namespace API.Services
{
    public interface ILocationService
    {
        List<ProvinceDto>? GetAllProvince();
        // List<DictrictDto>? GetDictrictByProvinceId(int id);
        // List<WardDto>? GetWardByDictrictId(int id);
        bool SaveChanges();
    }
}