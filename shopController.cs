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
    public class shopController : ApiController
    {
        [HttpGet]

        [Route("api/shop/all")]

        public HttpResponseMessage GetAllShopping()

        {

            var data = ShopsService.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, data);

        }

        [HttpGet]

        [Route("api/Shop/{id}")]

        public HttpResponseMessage GetShopping(int id)

        {

            var data = ShopsService.Get(id);

            if (data != null)

            {

                return Request.CreateResponse(HttpStatusCode.OK, data);

            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "not found");

        }

        [HttpPost]

        [Route("api/shop/create")]

        public HttpResponseMessage CreateShopping(ShopDTO donation)

        {

            ShopsService.Create(donation);

            return Request.CreateResponse(HttpStatusCode.OK, " created successfully");

        }

        [HttpDelete]

        [Route("api/shop/delete/{id}")]

        public HttpResponseMessage DeleteShopping(int id)

        {

            var result = ShopsService.Delete(id);

            if (result)

            {

                return Request.CreateResponse(HttpStatusCode.OK, " deleted successfully");

            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "not found");

        }

    }
}
