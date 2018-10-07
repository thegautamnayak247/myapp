using MyApplication.api.Models;
using MyApplication.Dal;
using System.Web.Http;

namespace MyApplication.api.Controllers
{
    public class LoginController : ApiController
    {
        private ILoginDal loginDal;
        public LoginController(): this(new LoginDal())
        {

        }
        public LoginController(ILoginDal _loginDal)
        {
            loginDal = _loginDal;
        }
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Post([FromBody]LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var isSuccess = loginDal.VerifyLogin(login.EmailId, login.Password);
                return Ok(isSuccess);
            }
            return BadRequest();
        }
    }
}
