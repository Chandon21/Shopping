using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shopping.Controllers
{
    public class ShoppingListController : ApiController
    {
        [HttpGet]
        [Route("api/shoppinglist/all")]
        public HttpResponseMessage GetAllShoppingLists()
        {
            var data = ShoppingListService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/shoppinglist/{id}")]
        public HttpResponseMessage GetShoppingList(int id)
        {
            var data = ShoppingListService.Get(id);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping list not found");
        }

        [HttpPost]
        [Route("api/shoppinglist/create")]
        public HttpResponseMessage CreateShoppingList(ShoppingListDTO shoppingListDto)
        {
            ShoppingListService.Create(shoppingListDto);
            return Request.CreateResponse(HttpStatusCode.OK, "Shopping list created successfully");
        }

        [HttpDelete]
        [Route("api/shoppinglist/delete/{id}")]
        public HttpResponseMessage DeleteShoppingList(int id)
        {
            var result = ShoppingListService.Delete(id);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Shopping list deleted successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Shopping list not found");
        }
        [HttpGet]
        [Route("api/shoppinglist/category/{category}")]
        public HttpResponseMessage GetShoppingListsByCategory(string category)
        {
            var data = ShoppingListService.GetByCategory(category);
            if (data != null && data.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "No shopping lists found for the given category");
        }

    }
}
