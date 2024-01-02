using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;

namespace API.Services
{
    public interface IReviewDestinationService
    {
        List<ReviewDestination>? GetAllReviewDestination();
        ReviewDestination? GetReviewDestinationById(int id);
        List<ReviewDestination>? GetReviewDestinationByDesId(int id);
        void CreateReviewDestination(ReviewDestinationAdd ReviewDestination, string username, int desId);
        ReviewDestination? GetLastReviewDestinationByUserId(int userId);
        bool SaveChanges();
    }
}