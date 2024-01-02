using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;

namespace API.Repositories
{
    public interface IUserRepository
    {
        User? GetUserById(int id);
        User? GetUserByUsername(string username);
        IEnumerable<User>? GetUsersByRole(int idRole);

        Role? GetRolesOfUser(int idUser);
        Role? GetRoleById(int id);
        void CreateUser(User user);
        void CreatePlan(Plan plan);
        void CreatePlanDestination(int planId, int desId);
        Plan? GetLastPLanByUserId(int userId);
        List<Plan>? GetPLanByUserId(int userId);
        bool SaveChanges();
        List<User>? GetAllUser();

        bool UpdateUser(User user);
    }
}