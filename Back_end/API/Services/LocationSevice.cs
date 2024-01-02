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
using API.Models;
using AutoMapper;

namespace API.Services
{
    public class LocationService : ILocationService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public LocationService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProvinceDto>? GetAllProvince()
        {
            return _mapper.Map<List<Province>, List<ProvinceDto>>(_context.Provinces.ToList());
        }

        // public List<DictrictDto>? GetDictrictByProvinceId(int id)
        // {
        //     var districts = _context.Dictricts
        //         .Where(d => d.ProvinceId == id)
        //         .ToList();
        //     return _mapper.Map<List<Dictrict>, List<DictrictDto>>(districts);
        // }

        // public List<WardDto>? GetWardByDictrictId(int id)
        // {
        //     var wards = _context.Wards
        //         .Where(d => d.DictrictId == id)
        //         .ToList();
        //     return _mapper.Map<List<Ward>, List<WardDto>>(wards);
        // }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}