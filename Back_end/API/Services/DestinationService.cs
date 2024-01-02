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
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUploadImgService _uploadImgService;
        public DestinationService(IDestinationRepository repository, IUserRepository userRepository, IMapper mapper, IUploadImgService uploadImgService)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
            _uploadImgService = uploadImgService;
        }

        public void CreateDestination(DestinationAdd destinationadd, string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            var destination = _mapper.Map<DestinationAdd, Destination>(destinationadd);
            var linkImage = _uploadImgService.UploadImage("webTravel", username, destinationadd.ImgAvatarFile);
            destination.UserId = user.Id;
            destination.ImgAvatar = linkImage.Result;
            destination.CreatedAt = DateTime.Now;
            destination.UpdateAt = DateTime.Now;
            _repository.CreateDestination(destination);

        }

        public List<Destination>? GetAllDestination()
        {
            return _repository.GetAllDestination();
        }

        public DestinationDto? GetDestinationById(int id)
        {
            var des = _repository.GetDestinationById(id);
            var desmap = _mapper.Map<Destination, DestinationDto>(des);
            desmap.NameProvince = des.Province.Name;
            return desmap;
        }

        // public DestinationDto? GetDestinationByName(string name)
        // {
        //     return _mapper.Map<Destination, DestinationDto>(_repository.GetDestinationByName(name));
        // }

        public List<Destination>? GetDestinationByWardId(int wardId)
        {
            return _repository.GetDestinationByWardId(wardId);
        }

        public List<DestinationDto>? GetDestinationDuLich(int id)
        {
            var des = _repository.GetDestinationDuLich(id);
            return _mapper.Map<List<Destination>, List<DestinationDto>>(des);

        }

        public List<DestinationDto>? GetDestinationPopular()
        {
            var des = _repository.GetDestinationPopular();
            List<DestinationDto> desmap = _mapper.Map<List<Destination>, List<DestinationDto>>(des);
            return desmap;

        }

        public DestinationDto? GetDestinationProvinceByProId(int id)
        {
            var des = _repository.GetDestinationProvinceByProId(id);
            var desmap = _mapper.Map<Destination, DestinationDto>(des);
            desmap.UserDto = _mapper.Map<User, UserDto>(des.User);
            return desmap;
        }

        public List<DestinationDto>? GetDestinationsByName(string name)
        {
            return _mapper.Map<List<Destination>, List<DestinationDto>>(_repository.GetDestinationsByName(name));
        }

        public List<DestinationDto>? GetDestinationsOfProvice(int provinceId)
        {
            var listDestination = _repository.GetDestinationsOfProvice(provinceId);
            List<DestinationDto> destinationsOfProvince = new List<DestinationDto>();
            // List<DestinationDto> destinationsOfProvince =  _mapper.Map<List<Destination>, List<DestinationDto>>(listDestination);
            foreach (var Destination in listDestination)
            {
                var des = _mapper.Map<Destination, DestinationDto>(Destination);
                des.NameProvince = Destination.Province.Name;
                destinationsOfProvince.Add(des);

            }
            return destinationsOfProvince;
        }

        public List<DestinationDto>? GetHotel_RestuarantPopular()
        {
            var des = _repository.GetHotel_RestuarantPopular();
            return _mapper.Map<List<Destination>, List<DestinationDto>>(des);
        }

        //     public List<DestinationsByProvinceDTO> GetDestinationsByUserId(string username)
        //     {
        //         var user = _userRepository.GetUserByUsername(username);
        //         var markDestinations = _repository.GetMarkDestinationsByUserId(user.Id);
        //         // List<Province> provinces = _repository.GetAllProvinces();

        //         // var destinationsByProvinceList = new List<DestinationsByProvinceDTO>();

        //         // foreach (var province in provinces)
        //         // {
        //         //     var destinationsInProvince = destinations
        //         //         .Where(d => d.ProvinceId == province.Id)
        //         //         .ToList();

        //         //     var ProGetImg = "";
        //         //     try{
        //         //         ProGetImg = GetDestinationProvinceByProId(province.Id).ImgAvatar;
        //         //     }
        //         //     catch{
        //         //         ProGetImg = "https://dongphucvina.vn/wp-content/uploads/2022/02/quoc-ky-viet-nam-719x400.jpg";
        //         //     }
        //         //     var destinationsByProvinceDTO = new DestinationsByProvinceDTO
        //         //     {
        //         //         ProvinceId = province.Id,
        //         //         NameProvince = province.Name,
        //         //         ImageProvince = ProGetImg,
        //         //         Destinations = destinationsInProvince
        //         //     };

        //         //     destinationsByProvinceList.Add(destinationsByProvinceDTO);
        //         // }

        //         // return destinationsByProvinceList;
        //         var destinationsByProvince = markDestinations
        // .GroupBy(md => md.Destination.ProvinceId)
        // .Select(g =>
        // {
        //     DestinationsByProvinceDTO destinationByProvince = null;

        //     try
        //     {
        //         var destinationProvince = GetDestinationProvinceByProId(g.Key);
        //         destinationByProvince = new DestinationsByProvinceDTO
        //         {
        //             ProvinceId = g.Key,
        //             NameProvince = g.First().Destination.Province.Name,
        //             ImageProvince = destinationProvince.ImgAvatar,
        //             Destinations = g.Select(md => md.Destination).ToList()
        //         };
        //     }
        //     catch (Exception ex)
        //     {
        //         // Xử lý ngoại lệ (ví dụ: gán một giá trị mặc định cho ImageProvince)
        //         destinationByProvince = new DestinationsByProvinceDTO
        //         {
        //             ProvinceId = g.Key,
        //             NameProvince = g.First().Destination.Province.Name,
        //             ImageProvince = "default_image.jpg", // Giá trị mặc định
        //             Destinations = g.Select(md => md.Destination).ToList()
        //         };

        //         // Ghi log ngoại lệ nếu cần thiết
        //         Console.WriteLine($"Error occurred while getting ImageProvince: {ex.Message}");
        //     }

        //     return destinationByProvince;
        // })
        // .ToList();

        // return destinationByProvince
        //     }

        public List<DestinationsByProvinceDTO> GetDestinationsByUserId(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            var markDestinations = _repository.GetMarkDestinationsByUserId(user.Id);

            var destinationsByProvince = markDestinations
                .GroupBy(md => md.Destination.ProvinceId)
                .Select(g =>
                {
                    DestinationsByProvinceDTO destinationByProvince = null;

                    try
                    {
                        var destinationProvince = GetDestinationProvinceByProId(g.Key);
                        destinationByProvince = new DestinationsByProvinceDTO
                        {
                            ProvinceId = g.Key,
                            NameProvince = g.First().Destination.Province.Name,
                            ImageProvince = destinationProvince.ImgAvatar,
                            Destinations = _mapper.Map<List<Destination>, List<DestinationDto>>(g.Select(md => md.Destination).ToList())
                        };
                    }
                    catch (Exception ex)
                    {
                        destinationByProvince = new DestinationsByProvinceDTO
                        {
                            ProvinceId = g.Key,
                            NameProvince = g.First().Destination.Province.Name,
                            ImageProvince = "default_image.jpg",
                            Destinations = _mapper.Map<List<Destination>, List<DestinationDto>>(g.Select(md => md.Destination).ToList())
                        };

                        Console.WriteLine($"Error occurred while getting ImageProvince: {ex.Message}");
                    }

                    return destinationByProvince;
                })
                .ToList();

            return destinationsByProvince;
        }

        public List<DestinationDto>? GetDestinationHotelOfProvice(int provinceId)
        {
            var listDestination = _repository.GetDestinationHotelOfProvice(provinceId);
            List<DestinationDto> destinationsOfProvince = new List<DestinationDto>();
            // List<DestinationDto> destinationsOfProvince =  _mapper.Map<List<Destination>, List<DestinationDto>>(listDestination);
            foreach (var Destination in listDestination)
            {
                var des = _mapper.Map<Destination, DestinationDto>(Destination);
                des.NameProvince = Destination.Province.Name;
                destinationsOfProvince.Add(des);

            }
            return destinationsOfProvince;
        }

        public void CreateMarkDes(string username, MarkDesAdd desId)
        {
            var user = _userRepository.GetUserByUsername(username);
            foreach (var itemdesId in desId.DesId)
            {
                _repository.CreateMarkDes(new MarkDestination
                {
                    UserId = user.Id,
                    DestinationId = itemdesId,
                    CreatedAt = DateTime.Now
                });
            }
        }
    }
}