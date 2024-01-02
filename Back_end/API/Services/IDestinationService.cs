using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;

namespace API.Services
{
    public interface IDestinationService
    {
        void CreateDestination(DestinationAdd destination, string username);
        List<Destination>? GetAllDestination();
        DestinationDto? GetDestinationById(int id);
        List<Destination>? GetDestinationByWardId(int wardId);
        List<DestinationDto>? GetDestinationsOfProvice(int provinceId);
        List<DestinationDto>? GetHotel_RestuarantPopular();
        List<DestinationDto>? GetDestinationsByName(string name);
        List<DestinationDto>? GetDestinationPopular();
        DestinationDto? GetDestinationProvinceByProId(int id);
        List<DestinationDto>? GetDestinationDuLich(int id); 
        List<DestinationsByProvinceDTO> GetDestinationsByUserId(string username);
        List<DestinationDto>? GetDestinationHotelOfProvice(int provinceId);
        void CreateMarkDes(string username, MarkDesAdd desId);
    }
}