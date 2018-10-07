using AutoMapper;
using MyApplication.api.Models;
using MyApplication.Dal;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using DTO = MyApplication.Core;

namespace MyApplication.api.Controllers
{
    public class UsersController : ApiController
    {
        IUserDal registrationDal;
        public UsersController(): this(new UserDal())
        {

        }
        public UsersController(IUserDal _registrationDal)
        {
            registrationDal = _registrationDal;
        }
        [HttpGet]
        [HttpHead]
        [Route("api/Users",Name ="GetUser")]
        public IHttpActionResult Get()
        {
            var usersDto = registrationDal.GetUsers();
            var users = Mapper.Map<List<User>> (usersDto);
            return Ok(users);
        }
        [HttpGet]
        [Route("api/Users/{userId}", Name ="GetUserById")]
        public IHttpActionResult GetUserById(int userId)
        {
            var userDto = registrationDal.GetUserById(userId);
            if(userDto == null)
            {
                return NotFound();
            }
            var user = Mapper.Map<User>(userDto);
            return Ok(user);
        }

        [HttpPost]
        [Route("api/Users")]
        public IHttpActionResult Save([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                var userDto = Mapper.Map<DTO.User>(user);
                registrationDal.SaveUser(userDto);
                return CreatedAtRoute<User>("GetUserById", new { userId = user.UserId }, user);
            }
            return BadRequest("Invalid data");
        }

        [HttpOptions]
        [Route("api/Users", Name = "Options")]
        public IHttpActionResult Options()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "GET,POST,OPTIONS");
            return Ok();
        }
    }
}
