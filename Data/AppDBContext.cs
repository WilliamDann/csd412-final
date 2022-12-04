using Microsoft.EntityFrameworkCore;
using csd412_final.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace csd412_final.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) 
            : base(options)
        { 
        
        }

        public DbSet<Collection> collections { get; set; }
    }
}
