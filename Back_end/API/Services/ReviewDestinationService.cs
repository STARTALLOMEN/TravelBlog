using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using API.Data.Entities;
using API.Models;
using API.Repositories;

namespace API.Services
{
    public class ReviewDestinationService : IReviewDestinationService
    {
        private readonly IReviewDestinationRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUploadImgService _uploadImgService;

        public ReviewDestinationService(IReviewDestinationRepository repository, IUserRepository userRepository, IMapper mapper, IUploadImgService uploadImgService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _uploadImgService = uploadImgService;

        }

        public void CreateReviewDestination(ReviewDestinationAdd reviewDestinationadd, string username, int desId)
        {
            var user = _userRepository.GetUserByUsername(username);
            var ReviewDestination = _mapper.Map<ReviewDestinationAdd, ReviewDestination>(reviewDestinationadd);
            ReviewDestination.UserId = user.Id;
            ReviewDestination.DestinationId = desId;
            ReviewDestination.CreatedAt = DateTime.Now;
            ReviewDestination.UpdateAt = DateTime.Now;
            _repository.CreateReviewDestination(ReviewDestination);
            var lastQues = _repository.GetLastReviewDestinationByUserId(user.Id);
            if (reviewDestinationadd.ImageReviewsFile != null)
            {
                
                foreach (var image in reviewDestinationadd.ImageReviewsFile)
                {
                    var linkImage = _uploadImgService.UploadImage("ReviewDestinationImage", username, image);
                    var imageReviewDestination = new ImageReview{
                        Image = linkImage.Result,
                        ReviewDestinationId = lastQues.Id
                    };
                    _repository.CreateImageReview(imageReviewDestination);
                }
            }
        }

        public List<ReviewDestination>? GetAllReviewDestination()
        {
            throw new NotImplementedException();
        }

        public ReviewDestination? GetLastReviewDestinationByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public List<ReviewDestination>? GetReviewDestinationByDesId(int id)
        {
            throw new NotImplementedException();
        }

        public ReviewDestination? GetReviewDestinationById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}