using CourseProject.DB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.DB.Domain
{
    public class AppDatabaseContext : DbContext
    {
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options) {}
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Operation> Operations { get; set; }
    }
}