using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace API.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly DataContext _context;
        public LocationRepository(DataContext context)
        {
            _context = context;
        }

        public List<Province>? GetAllProvince()
        {
            return _context.Provinces.ToList();
        }

        // public List<Dictrict>? GetDictrictByProvinceId(int id)
        // {
        //     var districts = _context.Dictricts
        //         .Where(d => d.ProvinceId == id)
        //         .ToList();
        //     return districts;
        // }

        // public List<Ward>? GetWardByDictrictId(int id)
        // {
        //     var wards = _context.Wards
        //         .Where(d => d.DictrictId == id)
        //         .ToList();
        //     return wards;
        // }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}