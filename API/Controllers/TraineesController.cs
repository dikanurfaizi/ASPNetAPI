using API.Models;
using API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace API.Controllers
{
    public class TraineesController : ApiController
    {
        readonly TraineeRepository traineeRepository = new TraineeRepository();

        public Task<Trainee> Get(int Id)
        {
            return traineeRepository.Get(Id);
        }

        public IHttpActionResult Put(Trainee trainee, int Id)
        {
            if (traineeRepository.Update(trainee, Id) == 1)
            {
                return Ok("Trainee data has been changed");
            }
            else
            {
                return NotFound();
            }
        }

        public IEnumerable<Trainee> Get()
        {
            return traineeRepository.Get();
        }
    }
}
