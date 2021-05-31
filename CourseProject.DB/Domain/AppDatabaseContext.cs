using CourseProject.DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DB.Domain
{
    internal class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options) {}
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}
