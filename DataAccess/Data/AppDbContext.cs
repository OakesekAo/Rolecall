using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<ApplicationUser>(options)
        {

        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
