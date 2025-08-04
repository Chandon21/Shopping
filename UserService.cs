using AutoMapper;
using BLL.DTOs;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static bool Register(UserDTO userDto)


        {


            var repo = new UserRepo();

            if (repo.Exists(userDto.Username))


            {


                return false;


            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>());


            var mapper = new Mapper(config);


            var user = mapper.Map<User>(userDto);


            repo.Register(user);

            return true;


        }

        public static UserDTO Login(string username, string password)


        {


            var repo = new UserRepo();


            var user = repo.Login(username, password);

            if (user == null)


                return null;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());


            var mapper = new Mapper(config);

            return mapper.Map<UserDTO>(user);


        }

    }
}
