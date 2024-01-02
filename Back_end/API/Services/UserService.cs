using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using API.Models;
using API.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public User? GetUserByUsername(string username)
        {
            return _repository.GetUserByUsername(username);
        }
        public void CreateUser(User user)
        {
            _repository.CreateUser(user);
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
        }
        public bool SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public List<UserDto>? GetAllUser()
        {
            var listUser = _repository.GetAllUser();
            return _mapper.Map<List<User>, List<UserDto>>(listUser);
        }

        public bool UpdateUser(UserDto userDto)
        {
            try
            {
                return _repository.UpdateUser(_mapper.Map<UserDto, User>(userDto));
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void CreatePan(PlanAdd planadd, string username)
        {
            var user = _repository.GetUserByUsername(username);
            var plan = _mapper.Map<PlanAdd, Plan>(planadd);
            plan.UserId = user.Id;
            plan.CreatedAt = DateTime.Now;
            plan.UpdateAt = DateTime.Now;
            _repository.CreatePlan(plan);
            var lastQues = _repository.GetLastPLanByUserId(user.Id);
            if (planadd.DesId != null)
            {
                _repository.CreatePlanDestination(lastQues.Id, planadd.DesId);
            }
        }

        public List<PlanDto>? GetPLanByUserId(string username)
        {
            var user = _repository.GetUserByUsername(username);
            var plan =  _repository.GetPLanByUserId(user.Id);
            var planmap =  _mapper.Map<List<Plan>, List<PlanDto>>(plan);
            return planmap;
        }

        public void CreatePlanDestination(int planId, int desId)
        {
            _repository.CreatePlanDestination(planId,desId);
        }
    }
}