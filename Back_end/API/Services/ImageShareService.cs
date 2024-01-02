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
    public class ImageShareService : IImageShareService
    {
        private readonly IImageShareRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUploadImgService _uploadImgService;

        public ImageShareService(IImageShareRepository repository, IUserRepository userRepository, IMapper mapper, IUploadImgService uploadImgService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _uploadImgService = uploadImgService;

        }

        public void CreateImageShare(ImageShareAdd imageShareAdd, string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            var ImageShare = _mapper.Map<ImageShareAdd, ImageShare>(imageShareAdd);
            ImageShare.UserId = user.Id;
            ImageShare.CreatedAt = DateTime.Now;
            ImageShare.UpdateAt = DateTime.Now;
            var linkAva = _uploadImgService.UploadImage("ImageShareImage", username, imageShareAdd.ImgAvatarFile);
            ImageShare.ImageAvatar = linkAva.Result;
            _repository.CreateImageShare(ImageShare);
            if (imageShareAdd.ListImgShareFile != null)
            {
                var lastQues = _repository.GetLastImageShareByUserId(user.Id);
                foreach (var image in imageShareAdd.ListImgShareFile)
                {
                    var linkImage = _uploadImgService.UploadImage("ImageShareImage", username, image);
                    var imageImageShare = new ImageShareDetail
                    {
                        Image = linkImage.Result,
                        ImageShareId = lastQues.Id
                    };
                    _repository.CreateImageShareDetail(imageImageShare);
                }
                if (imageShareAdd.DesId != null)
                {
                    foreach (var desId in imageShareAdd.DesId)
                    {
                        var imageImageShare = new ImageShareDestination
                        {
                            DestinationId = desId,
                            ImageShareId = lastQues.Id
                        };
                        _repository.CreateImageShareDes(imageImageShare);
                    }
                }
            }

        }

        public List<ImageShare>? GetAllImageShare()
        {
            return _repository.GetAllImageShare();
        }

        public ImageShare? GetImageShareById(int id)
        {
            return _repository.GetImageShareById(id);
        }

        public ImageShare? GetImageShareByName(string name)
        {
            return _repository.GetImageShareByName(name);
        }

        public List<ImageShare>? GetImageSharesByName(string name)
        {
            return _repository.GetImageSharesByName(name);
        }

        public List<ImageShareDto>? GetImageSharesOfDestination(int desId)
        {
            var listImageShare = _repository.GetAllImageShare();
            var listImageShareDes = new List<ImageShareDto>();
            if (listImageShare != null)
            {
                foreach (var ImageShare in listImageShare)
                {
                    foreach (var ImageSharedDes in ImageShare.ImageShareDestinations)
                    {
                        if (ImageSharedDes.DestinationId == desId)
                        {
                            listImageShareDes.Add(_mapper.Map<ImageShare, ImageShareDto>(ImageShare));
                        }
                    }
                }
            }
            return listImageShareDes;
        }
    }
}