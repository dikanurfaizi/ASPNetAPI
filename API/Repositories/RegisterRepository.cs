using API.Models;
using API.Repositories.Interfaces;
using API.ViewModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Repositories
{
    public class RegisterRepository : IRegisterRepository
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public int Create(RegisterViewModel register)
        {
            var spName = "SP_InsertAccount";
            parameters.Add("@Name", register.Name);
            parameters.Add("@Email", register.Email);
            parameters.Add("@Phone", register.Phone);
            parameters.Add("@Address", register.Address);
            parameters.Add("@Birth", register.Birth);
            parameters.Add("@Password", register.Password);
            var result = connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}