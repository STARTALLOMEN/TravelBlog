using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;

namespace API.Services
{
    public interface IUserService
    {
        User? GetUserByUsername(string username);
        void CreateUser(User user);
        bool SaveChanges();
        List<UserDto>? GetAllUser();
        bool UpdateUser(UserDto userDto);
        void CreatePan(PlanAdd Plan, string username);
        List<PlanDto>? GetPLanByUserId(string username);
        void CreatePlanDestination(int planId, int desId);
    }
}