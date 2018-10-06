using AutoMapper;
using MyApplication.api.Models;
using MyApplication.Dal;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using DTO = MyApplication.Core;

namespace MyApplication.api.Controllers
{
    public class RegistrationsController : ApiController
    {
        IRegistrationDal registrationDal;
        public RegistrationsController(): this(new RegistrationDal())
        {

        }
        public RegistrationsController(IRegistrationDal _registrationDal)
        {
            registrationDal = _registrationDal;
        }
        [HttpGet]
        [HttpHead]
        [Route("api/Registrations",Name ="GetUser")]
        public IHttpActionResult Get()
        {
            var usersDto = registrationDal.GetUsers();
            var users = Mapper.Map<List<User>> (usersDto);
            return Ok(users);
        }
        [HttpGet]
        [Route("api/Registrations/{userId}", Name ="GetUserById")]
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
        [Route("api/Registrations")]
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
        [Route("api/Registrations", Name = "Options")]
        public IHttpActionResult Options()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "GET,POST,OPTIONS");
            return Ok();
        }
    }
}
