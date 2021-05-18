using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CourseProject.DB.Domain;
using CourseProject.DB.Domain.Entities;
using CourseProject.DB.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CourseProject.DB
{
    public class Database
    {
        private AppDatabaseContext _ctx;
        private static Database _instance;
        private Database()
        {
            _ctx = new AppDatabaseContext(
                new DbContextOptionsBuilder<AppDatabaseContext>()
                    .UseSqlServer("Server=tcp:biblibdbserver.database.windows.net,1433;Initial Catalog=Course_Project_Db;Persist Security Info=False;User ID=Negativchik09;Password=SuperPassword123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
                    .Options
                );
        }

        public static Database Instance => _instance;

        static Database()
        {
            _instance = new Database();
        }
        
        public async void CreateProduct(ProductDTO product)
        {
            await _ctx.Products.AddAsync(product.Product);
            await _ctx.SaveChangesAsync();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return _ctx.Products.Select(x => new ProductDTO(x) 
                { 
                    Category = new CategoryDTO(_ctx.Categories
                        .First(y => y.Id == x.CategoryId))
                });
        }

        public IEnumerable<ProductDTO> GetProducts(CategoryDTO category)
        {
            return _ctx.Products.Where(x=> x.CategoryId == category.Id).Select(x => new ProductDTO(x) 
            { 
                Category = new CategoryDTO(_ctx.Categories
                    .First(y => y.Id == x.CategoryId))
            });
        }

        public async void AddProduct(ProductDTO product)
        {
            _ctx.Products.First(x => x.Articul == product.Articul).Amount += product.Count;
            await _ctx.SaveChangesAsync();
        }

        public async void UpdateProduct(ProductDTO product)
        {
            var DBproduct = _ctx.Products.First(x => x.Articul == product.Articul);
            DBproduct = product.Product;
            await _ctx.SaveChangesAsync();
        }
        
        public async void RemoveProducts(ProductDTO product)
        {
            _ctx.Products.First(x => x.Articul == product.Articul).Amount -= product.Count;
            await _ctx.SaveChangesAsync();
        }

        public async void DeleteProduct(ProductDTO productDto)
        {
            _ctx.Products.Remove(productDto.Product);
            await _ctx.SaveChangesAsync();
        }
        
        public async void CreateCategory(CategoryDTO category)
        {
            await _ctx.Categories.AddAsync(category.Category);
            await _ctx.SaveChangesAsync();
        }

        public async void RemoveCategory(CategoryDTO category)
        {
            _ctx.Categories.Remove(category.Category);
            await _ctx.SaveChangesAsync();
        }

        public IEnumerable<CategoryDTO> SubCategories(CategoryDTO category)
        {
            return _ctx.Categories.Where(x => x.ParentId == category.Id).Select(x => new CategoryDTO(x));
        }

        public IEnumerable<OperationDTO> GetOperations(Expression<Func<Operation,bool>> predicate = null)
        {
            return predicate == null ? _ctx.Operations.Select(x => new OperationDTO(x)) 
                : _ctx.Operations.Where(predicate).Select(x => new OperationDTO(x));
        }

        public async void AddOperation(OperationDTO operation)
        {
            await _ctx.AddAsync(operation.Operation);
            await _ctx.SaveChangesAsync();
        }
    }
}