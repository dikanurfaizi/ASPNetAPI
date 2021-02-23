using API.Repositories;
using API.ViewModels;
using System.Web.Http;

namespace API.Controllers
{
    public class RegistersController : ApiController
    {
        RegisterRepository registerRepository = new RegisterRepository();
        public IHttpActionResult Post(RegisterViewModel register)
        {
            if (register != null)
            {
                registerRepository.Create(register);
                return Ok("Account has been created");
            }
            else
            {
                return BadRequest("Account cannot be created");
            }
        }
    }
}
