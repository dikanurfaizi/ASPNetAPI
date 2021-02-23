using API.ViewModels;
using API.Repositories;
using System.Linq;
using System.Web.Http;

namespace API.Controllers
{
    public class AccountsController : ApiController
    {
        readonly LoginRepository loginRepository = new LoginRepository();

        public IHttpActionResult Post(LoginViewModel login)
        {
            if (login != null)
            {
                var result = loginRepository.Get();
                result.FirstOrDefault(s => (s.Email == login.Email || s.Phone == login.Phone) 
                    && s.Password == login.Password);
                return Ok();
            }
            else
            {
                return BadRequest("Login Failed");
            }
        }

        public IHttpActionResult Put(LoginViewModel login)
        {
            if(login != null)
            {
                loginRepository.Update(login);
                return Ok("Password has changed");
            }
            else
            {
                return BadRequest("Password cannot be changed");
            }
        }
    }
}
