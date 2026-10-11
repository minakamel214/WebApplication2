using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<WebApplication2.Models.Student> Students { get; set; }
        public DbSet<WebApplication2.Models.Department> Departments { get; set; }
    }
}
