using Dapper;
using LoginForm.Interfaces;
using LoginForm.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace LoginForm.Services
{
    public class CRUDservices : ICRUDServices
    {
        private IConfiguration _configuration;
        public CRUDservices(IConfiguration configuration)
        {
            _configuration = configuration;            
        }
        public async Task<List<UserInfo>> GetUsersAsync()
        {
            // 1-Connection String
            var connectionString = _configuration.GetConnectionString("LoginDbCnSt");
            //var connectionString = _configuration["ConnectionStrings:LoginDbCnSt"];

            // 2- SQL Query or Stored Procedure
            var query = @"SELECT [FullName]
                        ,[Email]
                        ,[Address]
                        ,[RoleID]
                        ,[UserID]
                        ,[Tel]
                         FROM [LoginDb].[dbo].[UserInfo]";
            // 3-Creating an IDBConnection instance
            IDbConnection connection = new SqlConnection(connectionString);
                var result = await connection.QueryAsync<UserInfo>(query);
                return result.ToList();
       
        }    
    }
}