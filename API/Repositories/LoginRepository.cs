using API.Repositories.Interfaces;
using API.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Update(LoginViewModel login)
        {
            var spName = "SP_UpdatePassword";
            parameters.Add("@Email", login.Email);
            parameters.Add("@Password", login.Password);
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<LoginViewModel> Get()
        {
            var spName = "SP_RetrieveAccount";
            var result = connection.Query<LoginViewModel>(spName, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}