using Dapper;
using LoginForm.Interfaces;
using LoginForm.Models;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
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

        public async Task<List<LoginProperties>> CheckLoginInfoAsync(LoginProperties loginProperties)
        {
            var connectionString = _configuration.GetConnectionString("LoginDbCnSt");
            //var connectionString = _configuration["ConnectionStrings:LoginDbCnSt"];

            var query = String.Format("Select [Username],[Password] FROM [LoginDb].[dbo].[LoginProperties] where Username = '{0}' and Password = '{1}'", loginProperties.Username, loginProperties.Password);
            // 3-Creating an IDBConnection instance
            IDbConnection connection = new SqlConnection(connectionString);
            var result = await connection.QueryAsync<LoginProperties>(query);
            return result.ToList();
        }

     

        public async Task<IQueryable<UserInfo>> SearchUserAsync(UserInfo userInfo)
        {
            var connectionString = _configuration.GetConnectionString("LoginDbCnSt");
            //var connectionString = _configuration["ConnectionStrings:LoginDbCnSt"];

            List<string> predicate = new List<string>();
            if (userInfo.FullName is not null)
            {
                predicate.Add(string.Format("FullName = '{0}'", userInfo.FullName));
            }
            if (userInfo.Email is not null)
            {
                predicate.Add(string.Format("Email = '{0}'", userInfo.Email));
            }
            if (userInfo.Address is not null)
            {
                predicate.Add(string.Format("Address = '{0}'", userInfo.Address));
            }
            if (userInfo.Tel is not null)
            {
                predicate.Add(string.Format("Tel = '{0}'", userInfo.Tel));
            }
            var query = string.Format("SELECT [UserID],[RoleID],[Fullname],[Email],[Address],[Tel] FROM [LoginDb].[dbo].[UserInfo]");
            if (predicate.Count !=0)
            {
                query = query + " where ";
                
                int i = query.Count();
                int j = 0;                
                foreach (var item in predicate)
                {
                    if (j< i)
                    {
                        query= query + item + " or ";
                    }
                    else
                    {
                        query = query + item;
                    }
                }
            }
            // 3-Creating an IDBConnection instance
            IDbConnection connection = new SqlConnection(connectionString);
            var result = await connection.QueryAsync<UserInfo>(query);
            return result.AsQueryable();
        }
    }
}