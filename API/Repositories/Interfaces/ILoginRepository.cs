using API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories.Interfaces
{
    interface ILoginRepository
    {
        IEnumerable<LoginViewModel> Get();
        int Update(LoginViewModel login);
    }
}
