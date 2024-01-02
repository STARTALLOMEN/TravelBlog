using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Repositories
{
    public interface IReviewDestinationRepository
    {
        List<ReviewDestination>? GetAllReviewDestination();
        ReviewDestination? GetReviewDestinationById(int id);
        List<ReviewDestination>? GetReviewDestinationByDesId(int id);
        void CreateReviewDestination(ReviewDestination ReviewDestination);
        ReviewDestination? GetLastReviewDestinationByUserId(int userId);
        void CreateImageReview(ImageReview image);
        bool SaveChanges();
    }
}