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
    public class ImageShareRepository : IImageShareRepository
    {
        private readonly DataContext _context;
        public ImageShareRepository(DataContext context)
        {
            _context = context;
        }
        public List<ImageShare>? GetAllImageShare()
        {
            return _context.ImageShares.Include(p => p.ImageShareDestinations).ThenInclude(o => o.Destination)
                                .ToList();      
        }

        public ImageShare? GetImageShareById(int id)
        {
            return _context.ImageShares.FirstOrDefault(u => u.Id == id);
        }

        public List<ImageShare>? GetImageSharesByName(string name)
        {
            return _context.ImageShares.Where(u => u.Title == name).ToList();
        }
        public ImageShare? GetImageShareByName(string name)
        {
            var query =  _context.ImageShares
                                    .FirstOrDefault(u => u.Title == name);
            if(query == null)
            {
                query = _context.ImageShares.FirstOrDefault(delegate (ImageShare c)
                {
                    if (ConvertToUnSign(c.Title).IndexOf(name, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        return true;
                    else
                        return false;
                });

            }
            return query;
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

        // public List<ImageShare>? GetImageSharePopular()
        // {
        //    var top10ImageShares = _context.ImageShares
        //     .OrderByDescending(t => t.ReviewImageShares.Count())    
        //     .Take(10)
        //     .ToList();

        // return top10ImageShares;
        // }

        public void CreateImageShare(ImageShare ImageShare)
        {
            _context.ImageShares.Add(ImageShare);
            SaveChanges();
;       }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
        public ImageShare? GetLastImageShareByUserId(int userId)
        {
            var lastAddedQues = _context.ImageShares
                                        .Where(q => q.UserId == userId)
                                        .OrderByDescending(q => q.CreatedAt)
                                        .FirstOrDefault();
            return lastAddedQues;
        }

        public void CreateImageShareDetail(ImageShareDetail ImageShare)
        {
            _context.ImageShareDetails.Add(ImageShare);
            SaveChanges();
        }

        public void CreateImageShareDes(ImageShareDestination ImageShare)
        {
            _context.ImageShareDestinations.Add(ImageShare);
            SaveChanges();
        }

        // public void CreateImageShareDestination(int imageShareId, List<int> desId)
        // {
        //     foreach(int id in desId){
        //         _context.ImageShareDestinations.Add(new ImageShareDestination {
        //             ImageShareId = imageShareId,
        //             DestinationId = id
        //         });
        //         SaveChanges();
        //     }
        // }
    }
}