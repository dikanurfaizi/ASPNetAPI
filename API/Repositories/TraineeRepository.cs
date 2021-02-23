using API.Models;
using API.Repositories.Interfaces;
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
    public class TraineeRepository : ITraineeRepository
    {
        readonly DynamicParameters parameters = new DynamicParameters();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnection"].ConnectionString);

        public async Task<Trainee> Get(int Id)
        {
            var spName = "SP_RetrieveTrainee";
            parameters.Add("@Id", Id);
            var result = await connection.QueryAsync<Trainee>(spName, parameters, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public int Update(Trainee trainee, int Id)
        {
            var spName = "SP_UpdateTrainee";
            parameters.Add("@Id", Id);
            parameters.Add("@Name", trainee.Name);
            parameters.Add("@Phone", trainee.Phone);
            parameters.Add("@Address", trainee.Address);
            parameters.Add("@Birth", trainee.Birth);
            parameters.Add("@Email", trainee.Email);
            var result = connection.Execute(spName, parameters, commandType:CommandType.StoredProcedure);
            return result;
        }

        public IEnumerable<Trainee> Get()
        {
            var spName = "SP_RetrieveAllTrainee";
            var result = connection.Query<Trainee>(spName, commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}