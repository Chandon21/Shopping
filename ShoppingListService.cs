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
    public class ShoppingListService
    {
        public static List<ShoppingListDTO> GetAll()
        {
            var repo = new ShoppingListRepo();
            var data = repo.GetAll();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShoppingList, ShoppingListDTO>();
                cfg.CreateMap<Shops, ShopDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<ShoppingListDTO>>(data);
        }

        public static ShoppingListDTO Get(int id)
        {
            var repo = new ShoppingListRepo();
            var data = repo.Get(id);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShoppingList, ShoppingListDTO>();
                cfg.CreateMap<Shops, ShopDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<ShoppingListDTO>(data);
        }

        public static void Create(ShoppingListDTO shoppingListDto)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShoppingList, ShoppingListDTO>();
                cfg.CreateMap<Shops, ShopDTO>();
            });


            var mapper = new Mapper(config);
            var shoppingList = mapper.Map<ShoppingList>(shoppingListDto);

            var repo = new ShoppingListRepo();
            repo.Create(shoppingList);
        }

        public static bool Delete(int id)
        {
            var repo = new ShoppingListRepo();
            var shoppingList = repo.Get(id);
            if (shoppingList == null)
                return false;

            repo.Delete(id);
            return true;
        }
        public static List<ShoppingListDTO> GetByCategory(string category)
        {
            var repo = new ShoppingListRepo();
            var data = repo.GetByCategory(category);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ShoppingList, ShoppingListDTO>();
                cfg.CreateMap<Shops, ShopDTO>();
            });

            var mapper = new Mapper(config);
            return mapper.Map<List<ShoppingListDTO>>(data);
        }

    }
}
