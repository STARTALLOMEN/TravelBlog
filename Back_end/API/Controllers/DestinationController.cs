using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;
        private readonly ILocationService _locationService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public DestinationController(IDestinationService destinationService, IUserService userService, IMapper mapper, ILocationService locationService)
        {
            _destinationService = destinationService;
            _locationService = locationService;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet("")]
        public ActionResult<List<DestinationDto>> GetAllDestination()
        {
            var listDestination = _destinationService.GetAllDestination();
            return _mapper.Map<List<Destination>, List<DestinationDto>>(listDestination);
        }
        [HttpGet("get-dentination/{id}")]
        public ActionResult<DestinationDto> GetDestinationById(int id)
        {
            var destination = _destinationService.GetDestinationById(id);
            return destination;
        }
        [HttpGet("popular")]
        public ActionResult<List<DestinationDto>> GetDestinationPopular()
        {
            var listDestination = _destinationService.GetDestinationPopular();
            return listDestination;
        }
        [HttpGet("popularHotelResstaurant")]
        public ActionResult<List<DestinationDto>> GetHotelResstaurantPopular()
        {
            var listDestination = _destinationService.GetHotel_RestuarantPopular();
            return listDestination;
        }

        [HttpGet("{name}")]
        public ActionResult<List<DestinationDto>> GetDestination(string name)
        {
            var Destination = _destinationService.GetDestinationsByName(name);
            return Destination;
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost("")]
        public ActionResult<string> Post([FromForm] DestinationAdd destinationAdd)
        {
            var des = destinationAdd;
            try
            {
                var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _destinationService.CreateDestination(destinationAdd, username);
                MessageReturn success = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Thêm địa điểm thành công"
                };
                return Ok(success);
            }
            catch (Exception ex)
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Thêm địa điểm thất bại."
                };
                return BadRequest();
            }
        }
        // [HttpPut("Update/{id}")]
        // public ActionResult<string> AddCar(int id, DestinationDto destinationDto)
        // {
        //     var des = destinationDto;
        //     try
        //     {
        //         var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //         _destinationService.CreateDestination(destinationAdd, username);
        //         MessageReturn success = new MessageReturn()
        //         {
        //             StatusCode = enumMessage.Success,
        //             Message = "Thêm địa điểm thành công"
        //         };
        //         return Ok(success);
        //     }
        //     catch (Exception ex)
        //     {
        //         MessageReturn fail = new MessageReturn()
        //         {
        //             StatusCode = enumMessage.Fail,
        //             Message = "Thêm địa điểm thất bại."
        //         };
        //         return BadRequest();
        //     }
        // }

        [HttpGet("/api/listProvince")]
        public ActionResult<List<ProvinceDto>> GetAllProvince()
        {
            var re = _locationService.GetAllProvince();
            return re;
        }
        // [HttpGet("/api/province/{id}")]
        // public ActionResult<List<DictrictDto>> GetDictrictByProvinceId(int id)
        // {
        //     var re = _locationService.GetDictrictByProvinceId(id);
        //     return re;
        // }
        // [HttpGet("/api/dictrict/{id}")]
        // public ActionResult<List<WardDto>> GetWardByDictrictId(int id)
        // {
        //     var re = _locationService.GetWardByDictrictId(id);
        //     return re;
        // }

        [HttpGet("/api/province/{id}/destination")]
        public ActionResult<List<DestinationDto>> GetDestinationsOfProvice(int id)
        {
            var re = _destinationService.GetDestinationsOfProvice(id);
            return re;
        }
        [HttpGet("/api/province/{id}/destinationPro")]
        public ActionResult<DestinationDto> GetDestinationProvinceByProId(int id)
        {
            var re = _destinationService.GetDestinationProvinceByProId(id);
            return re;
        }

        [HttpGet("{id}/du-lich")]
        public ActionResult<List<DestinationDto>> GetDestinationDuLich(int id)
        {
            var re = _destinationService.GetDestinationDuLich(id);
            return re;
        }

        [HttpGet("danh-dau")]
        public ActionResult<List<DestinationsByProvinceDTO>> GetDestinationDanhDau()
        {
            var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var destinationsByProvinceList = _destinationService.GetDestinationsByUserId(username);
            // var filteredDestinationsByProvinceList = destinationsByProvinceList
            //                                         .Where(dto => dto.Destinations.Any())
            //                                         .ToList();

            return destinationsByProvinceList;
        }

        [HttpGet("/api/province/{id}/destinationHotel")]
        public ActionResult<List<DestinationDto>> GetDestinationsHotelOfProvice(int id)
        {
            var re = _destinationService.GetDestinationHotelOfProvice(id);
            return re;
        }

        [Authorize(Roles = "admin, user")]
        [HttpPost("/api/MarkDesAdd")]
        public ActionResult<string> PostMarkDes([FromForm] MarkDesAdd destinationAdd)
        {
            try
            {
                var username = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                _destinationService.CreateMarkDes(username,destinationAdd);
                MessageReturn success = new MessageReturn()
                {
                    StatusCode = enumMessage.Success,
                    Message = "Thêm điểm đánh dấu thành công"
                };
                return Ok(success);
            }
            catch (Exception ex)
            {
                MessageReturn fail = new MessageReturn()
                {
                    StatusCode = enumMessage.Fail,
                    Message = "Thêm điểm đánh dấu thất bại."
                };
                return BadRequest();
            }
        }

    }
}