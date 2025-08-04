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
    public class ShopsService
    {
        public static List<ShopDTO> GetAll()

        {

            var srepo = new ShopRepo();

            var data = srepo.Get();

            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Shops, ShopDTO>();

            });

            var mapper = new Mapper(config); ;

            var ret = mapper.Map<List<ShopDTO>>(data);

            return ret;

        }

        public static ShopDTO Get(int id)

        {

            var srepo = new ShopRepo();

            var data = srepo.Get(id);

            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<Shops, ShopDTO>();

            });

            var mapper = new Mapper(config); ;

            var ret = mapper.Map<ShopDTO>(data);

            return ret;

        }

        public static void Create(ShopDTO s)

        {

            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<ShopDTO, Shops>();

            });

            var mapper = new Mapper(config); ;

            var st = mapper.Map<Shops>(s);

            var repo = new ShopRepo();

            repo.Create(st);

        }

        public static bool Update(int id, ShopDTO s)

        {

            var repo = new ShopRepo();

            var existingNews = repo.Get(id);

            if (existingNews == null)

            {

                return false;

            }

            var config = new MapperConfiguration(cfg =>

            {

                cfg.CreateMap<ShopDTO, Shops>();

            });

            var mapper = new Mapper(config);

            var updatedNews = mapper.Map<Shops>(s);

            updatedNews.Id = id;

            repo.Update(updatedNews);

            return true;

        }


        public static bool Delete(int id)

        {

            var repo = new ShopRepo();

            var existingNews = repo.Get(id);

            if (existingNews == null)

            {

                return false;

            }

            repo.Delete(id);

            return true;

        }

    }

}
 
