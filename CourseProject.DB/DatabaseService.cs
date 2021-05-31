using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProject.DB.Domain;
using CourseProject.DB.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CourseProject.DB
{
    public class DatabaseService : IDatabaseService
    {
        private class AppDatabaseContextFactory : IDesignTimeDbContextFactory<AppDatabaseContext>
        {
            public AppDatabaseContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDatabaseContext>();
                optionsBuilder.UseSqlServer("Server=tcp:biblibdbserver.database.windows.net,1433;Initial Catalog=Course_Project_Db;Persist Security Info=False;User ID=Negativchik09;Password=SuperPassword123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

                return new AppDatabaseContext(optionsBuilder.Options);
            }
        }
        private AppDatabaseContext _ctx;
        private static DatabaseService _instance;

        private DatabaseService()
        {
            _ctx = new AppDatabaseContextFactory().CreateDbContext(new string[]{});
        }

        public static DatabaseService Instance => _instance;

        static DatabaseService()
        {
            _instance = new DatabaseService();
        }

        public async Task CreateProduct(ProductDTO product)
        {
            await _ctx.Products.AddAsync(product.Product);
            await _ctx.SaveChangesAsync();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return _ctx.Products.Select(x => new ProductDTO(x));
        }

        public async Task AddProduct(ProductDTO product)
        {
            _ctx.Products.First(x => x.Articul == product.Articul).Amount += product.Count;
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductDTO product)
        {
            var DBproduct = _ctx.Products.First(x => x.Articul == product.Articul);
            var prod = product.Product;
            DBproduct.Articul = prod.Articul;
            DBproduct.Price = prod.Amount;
            DBproduct.Title = prod.Title;
            await _ctx.SaveChangesAsync();
        }
        
        public async Task RemoveProducts(ProductDTO product)
        {
            _ctx.Products.First(x => x.Articul == product.Articul).Amount -= product.Count;
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteProduct(ProductDTO productDto)
        {
            _ctx.Products.Remove(productDto.Product);
            await _ctx.SaveChangesAsync();
        }

        public IEnumerable<OperationDTO> GetOperations()
        {
            return _ctx.Operations.Select(x => new OperationDTO(x));
        }

        public async Task AddOperation(OperationDTO operation)
        {
            await _ctx.AddAsync(operation.Operation);
            await _ctx.SaveChangesAsync();
        }
    }
}
