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
    public class UserController : ApiController
    {

        [HttpPost]
        [Route("api/user/register")]
        public HttpResponseMessage Register(UserDTO userDto)
        {
            var success = UserService.Register(userDto);
            if (success)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "User registered successfully");
            }

            return Request.CreateResponse(HttpStatusCode.Conflict, "Username already exists");
        }

        [HttpPost]
        [Route("api/user/login")]
        public HttpResponseMessage Login([FromBody] UserDTO userDto)
        {
            var user = UserService.Login(userDto.Username, userDto.Password);

            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }

            return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid username or password");
        }

    }
}
