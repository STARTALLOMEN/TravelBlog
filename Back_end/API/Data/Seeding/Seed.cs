using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Data.Seeding
{
    public class Seed
    {
        public static void SeedRole(DataContext context)
        {
            if (context.Roles.Any()) return;

            context.Roles.Add(new Role(1, "admin"));
            context.Roles.Add(new Role(2, "user"));
            context.SaveChanges();
        }
        public static void SeedTypeDestination(DataContext context)
        {
            if (context.TypeDestinations.Any()) return;

            context.TypeDestinations.Add(new TypeDestination(1, "Sights_Scenery"));
            context.TypeDestinations.Add(new TypeDestination(2, "Hotel_Restaurant"));
            context.SaveChanges();
        }

        public static void SeedProvice(DataContext context)
        {
            if (context.Provinces.Any()) return;
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Data\\Seeding\\Provinces.json");
            string provinceText = File.ReadAllText(path);
            var provinces = JsonSerializer.Deserialize<List<ProvinceSeed>>(provinceText);
            foreach (var item in provinces)
            {
                var province = new Province()
                {
                    Id = Int32.Parse(item.idProvince),
                    Name = item.name
                };
                context.Provinces.Add(province);
            }
            context.SaveChanges();
        }

        // public static void SeedDictrict(DataContext context)
        // {
        //     if (context.Dictricts.Any()) return;
        //     string path = Path.Combine(Directory.GetCurrentDirectory(), "Data\\Seeding\\Dictricts.json");
        //     string dictrictText = File.ReadAllText(path);
        //     var dictricts = JsonSerializer.Deserialize<List<DictrictSeed>>(dictrictText);
        //     foreach (var item in dictricts)
        //     {
        //         var dictrict = new Dictrict()
        //         {
        //             Id = Int32.Parse(item.idDistrict),
        //             Name = item.name,
        //             ProvinceId = Int32.Parse(item.idProvince)
        //         };
        //         context.Dictricts.Add(dictrict);
        //     }
        //     context.SaveChanges();
        // }
        // public static void SeedWard(DataContext context)
        // {
        //     if (context.Wards.Any()) return;
        //     string path = Path.Combine(Directory.GetCurrentDirectory(), "Data\\Seeding\\Wards.json");
        //     string wardText = File.ReadAllText(path);
        //     var wards = JsonSerializer.Deserialize<List<WardSeed>>(wardText);
        //     foreach (var item in wards)
        //     {
        //         var ward = new Ward()
        //         {
        //             Id = Int32.Parse(item.idWard),
        //             Name = item.name,
        //             DictrictId = Int32.Parse(item.idDistrict)
        //         };
        //         context.Wards.Add(ward);
        //         context.SaveChanges();
        //     }
        // }
    
    }
}