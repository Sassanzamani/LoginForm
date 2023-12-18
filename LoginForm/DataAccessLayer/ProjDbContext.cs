using LoginForm.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginForm.DataAccessLayer
{
    public class ProjDbContext : DbContext
    {
        public static IConfiguration _configuration;
        string myDb1ConnectionString = _configuration.GetConnectionString("MsDbCnSt");
        public DbSet<LoginProperties> LoginProperties { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }


        public ProjDbContext(IConfiguration configuration): base()
        {
           _configuration = configuration;
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(myDb1ConnectionString);
        }
        
    }
   
}
