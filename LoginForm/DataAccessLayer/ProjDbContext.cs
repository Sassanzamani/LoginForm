using LoginForm.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginForm.DataAccessLayer
{
    public class ProjDbContext : DbContext
    {
        public static IConfiguration _configuration;
        string myDb1ConnectionString = _configuration.GetConnectionString("MsDbCnSt");

        
        public ProjDbContext()
        {
            
        }
    }
   
}
