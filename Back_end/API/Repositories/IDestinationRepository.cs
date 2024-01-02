using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Repositories
{
    public interface IDestinationRepository
    {
        List<Destination>? GetAllDestination();
        Destination? GetDestinationById(int id);
        Destination? GetDestinationProvinceByProId(int id);
        List<Destination>? GetDestinationsByName(string name);
        Destination? GetDestinationByName(string name);
        List<Destination>? GetDestinationByWardId(int wardId);
        List<Destination>? GetDestinationsOfProvice(int provinceId);
        List<Destination>? GetDestinationPopular();
        List<Destination>? GetHotel_RestuarantPopular();
        Task<bool> CreateDestination(Destination destination);
        List<Destination>? GetDestinationDuLich(int id);
        bool SaveChanges();
        List<Destination> GetDestinationsByUserId(int userId);
        List<MarkDestination>? GetMarkDestinationsByUserId(int userId);
        List<Destination>? GetDestinationHotelOfProvice(int provinceId);
        List<Province> GetAllProvinces();
        void CreateMarkDes(MarkDestination mark);
    }
}