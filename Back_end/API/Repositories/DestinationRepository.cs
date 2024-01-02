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
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DataContext _context;
        public DestinationRepository(DataContext context)
        {
            _context = context;
        }
        public List<Destination>? GetAllDestination()
        {
            return _context.Destinations.Include(p => p.Province)
                                 .ToList();
        }

        public Destination? GetDestinationById(int id)
        {
            return _context.Destinations.Include(p => p.Province).FirstOrDefault(u => u.Id == id);
        }

        public List<Destination>? GetDestinationsByName(string name)
        {
            string searchName = ConvertToUnSign(name.ToLower().Trim());

            var destinations = _context.Destinations
                .Include(p => p.Province)
                .ToList();

            var query = destinations
                .Where(u => ConvertToUnSign(u.Name.ToLower()).Contains(searchName))
                .ToList();

            return query;

        }
        public Destination? GetDestinationByName(string name)
        {
            var query = _context.Destinations.Include(p => p.Province)
                                    .FirstOrDefault(u => u.Name == name);
            if (query == null)
            {
                query = _context.Destinations.FirstOrDefault(delegate (Destination c)
                {
                    if (ConvertToUnSign(c.Name).IndexOf(name, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        return true;
                    else
                        return false;
                });

            }
            return query;
        }

        public List<Destination>? GetDestinationByWardId(int wardId)
        {
            return _context.Destinations.Where(u => u.ProvinceId == wardId).ToList();
        }

        public List<Destination>? GetDestinationsOfProvice(int provinceId)
        {
            return _context.Destinations.Where(u => u.ProvinceId == provinceId)
                                        .Where(u => ((int)u.ProvinceOrAreaOrPrArea) == 2)
                                        .Where(u => ((int)u.TypeDestinationId) == 1)
                                        .Include(p => p.Province).ToList();
        }
        public List<Destination>? GetDestinationHotelOfProvice(int provinceId)
        {
            return _context.Destinations.Where(u => u.ProvinceId == provinceId)
                                        .Where(u => ((int)u.TypeDestinationId) == 2)
                                        .Include(p => p.Province).ToList();
        }

        public static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(normalizedString[i]);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(normalizedString[i]);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        private string ConvertToUnSign(string input)
        {
            input = input.Trim();
            for (int i = 0x20; i < 0x30; i++)
            {
                input = input.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string str = input.Normalize(NormalizationForm.FormD);
            string str2 = regex.Replace(str, string.Empty).Replace('đ', 'd').Replace('Đ', 'D');
            while (str2.IndexOf("?") >= 0)
            {
                str2 = str2.Remove(str2.IndexOf("?"), 1);
            }
            return str2;
        }

        public List<Destination>? GetDestinationPopular()
        {
            //    var top10Destinations = _context.Destinations
            //     .OrderByDescending(t => t.ReviewDestinations.Count())    
            //     .Take(10)
            //     .ToList();
            var top10Destinations = _context.Destinations
                                    .Include(m => m.Province)
                                    .OrderByDescending(t => t.View)
                                    .Take(5)
                                    .ToList();

            return top10Destinations;
        }

        public async Task<bool> CreateDestination(Destination destination)
        {
            _context.Destinations.Add(destination);
            return SaveChanges();
            ;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public List<Destination>? GetHotel_RestuarantPopular()
        {
            var top10Destinations = _context.Destinations.Where(p => p.TypeDestinationId == 2)
                                    .Include(m => m.Province)
                                    .OrderByDescending(t => t.View)
                                    .Take(3)
                                    .ToList();

            return top10Destinations;
        }

        public Destination? GetDestinationProvinceByProId(int id)
        {
            return _context.Destinations.Where(u => ((int)u.ProvinceOrAreaOrPrArea) == 0)
                                        .Include(p => p.Province)
                                        .FirstOrDefault(u => u.ProvinceId == id);
        }

        public List<Destination>? GetDestinationDuLich(int id)
        {
            var des = GetDestinationById(id);
            List<Destination> destination = new List<Destination>();
            if (des != null)
            {
                if (((int)des.ProvinceOrAreaOrPrArea) == 0)
                {
                    destination = GetDestinationsOfProvice(des.ProvinceId);
                }
                if (((int)des.ProvinceOrAreaOrPrArea) == 1)
                {
                    destination = GetDestinationsByName(des.Name);
                }
            }
            return destination;
        }
        public List<Destination> GetDestinationsByUserId(int userId)
        {
            return _context.Destinations
                .Where(d => d.UserId == userId)
                .Include(d => d.Province)
                .ToList();
        }

        public List<Province> GetAllProvinces()
        {
            return _context.Provinces.ToList();
        }

        public List<MarkDestination>? GetMarkDestinationsByUserId(int userId)
        {
            return _context.MarkDestinations
                .Where(d => d.UserId == userId)
                .Include(d => d.Destination).ThenInclude(d => d.Province)
                .ToList();
        }

        public void CreateMarkDes(MarkDestination mark)
        {
            _context.MarkDestinations.Add(mark);
            SaveChanges();
        }
    }
}