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
    public class ReviewDestinationRepository : IReviewDestinationRepository
    {
        private readonly DataContext _context;
        public ReviewDestinationRepository(DataContext context)
        {
            _context = context;
        }

        public void CreateImageReview(ImageReview image)
        {
            _context.Add(image);
            SaveChanges();
        }

        public void CreateReviewDestination(ReviewDestination ReviewDestination)
        {
            _context.ReviewDestinations.Add(ReviewDestination);
            SaveChanges();
        }

        public List<ReviewDestination>? GetAllReviewDestination()
        {
            return _context.ReviewDestinations.Include(p => p.ImageReviews)
                                .ToList();
        }

        public ReviewDestination? GetLastReviewDestinationByUserId(int userId)
        {
            var lastAddedReview= _context.ReviewDestinations
                                        .Where(q => q.UserId == userId)
                                        .OrderByDescending(q => q.CreatedAt)
                                        .FirstOrDefault();
            return lastAddedReview;
        }

        public List<ReviewDestination>? GetReviewDestinationByDesId(int id)
        {
            var reviewDes = _context.ReviewDestinations
                                .Where(b => b.DestinationId == id)
                                .ToList();
            return reviewDes;
        }

        public ReviewDestination? GetReviewDestinationById(int id)
        {
            var reviewDes = _context.ReviewDestinations
                                .FirstOrDefault(b => b.Id == id);
            return reviewDes;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
    }
}