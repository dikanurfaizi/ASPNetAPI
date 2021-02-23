using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface ITraineeRepository
    {
        IEnumerable<Trainee> Get();
        Task<Trainee> Get(int Id);
        int Update(Trainee trainee, int Id);
    }
}
