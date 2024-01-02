using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public User? GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetUserByUsername(string username)
        {
            var user = _context.Users.Include(ru => ru.Role).FirstOrDefault(u => u.Username == username);
            return _context.Users.Include(ru => ru.Role).FirstOrDefault(u => u.Username == username);
        }
        public IEnumerable<User>? GetUsersByRole(int idRole)
        {
            List<User> users = _context.Users.Where(r => r.RoleId == idRole).ToList();
            return users;
        }
        public Role? GetRolesOfUser(int idUser)
        {
            // var user = GetUserById(idUser);
            // if (user == null) return null;

            // List<RoleUser> roleUsers = _context.RoleUser.Include(ru => ru.User).Include(ru => ru.Role)
            //                             .Where(u => u.UserId == idUser).ToList();

            // List<Role> roles = new List<Role>();
            // foreach (var roleUser in roleUsers)
            // {
            //     roles.Add(roleUser.Role);
            // }
            // return roles;
            var role = _context.Users.Where(r => r.Id == idUser).FirstOrDefault().Role;
            return role;
        }
        public Role? GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.Id == id);
        }
        public void CreateUser(User user)
        {
            // _context.RoleUsers.Add(new RoleUser());
            // if (user != null && _context != null)
            // {
            //     _context.Users.Add(user);
            //     _context.SaveChanges();
            //     var user_add = GetUserByUsername(user.Username);

            //     var role = new RoleUser()
            //     {
            //         UserId = user_add.Id,
            //         User = user_add,
            //         RoleId = 3,
            //         Role = GetRoleById(3)
            //     };
            //     _context.RoleUser.Add(role);
            //     _context.SaveChanges();

            // }
            if (user != null && _context != null){
                user.Role = GetRoleById(2);
                user.RoleId = 2;
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public List<User>? GetAllUser()
        {
            return (_context.Users.ToList());
        }

        public bool UpdateUser(User user)
        {
            var existUser = GetUserByUsername(user.Username);
            if (user == null) return false;
            existUser = user;
            return SaveChanges();
        }

        public void CreatePlan(Plan plan)
        {
            _context.Plans.Add(plan);
            SaveChanges();
        }

        public void CreatePlanDestination(int planId, int desId)
        {
            _context.PlanDestinations.Add(
                new PlanDestination{
                    PlanId = planId,
                    DestinationId = desId
                }
            );
            SaveChanges();
        }

        public Plan? GetLastPLanByUserId(int userId)
        {
            var lastAddedPlan = _context.Plans
                                        .Where(q => q.UserId == userId)
                                        .OrderByDescending(q => q.CreatedAt)
                                        .FirstOrDefault();
            return lastAddedPlan;
        }

        public List<Plan>? GetPLanByUserId(int userId)
        {
            var abc = _context.Plans.Include(p => p.PlanDestinations).ThenInclude(p => p.Destination)
                            .Where(p => p.UserId == userId).ToList(); 
            return _context.Plans.Include(p => p.PlanDestinations).ThenInclude(p => p.Destination)
                            .Where(p => p.UserId == userId).ToList();
        }
    }
}