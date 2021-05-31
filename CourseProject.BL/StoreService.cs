using System;
using System.Collections.Generic;
using System.Timers;
using CourseProject.BL.Enums;
using CourseProject.BL.Interface;
using CourseProject.BL.Records;
using CourseProject.DB;
using CourseProject.DB.DTO;

namespace CourseProject.BL
{
    public class StoreService : IStoreService
    {
        private readonly Database _db;

        public StoreService(Database db)
        {
            _db = db;
        }

        public void CreateProduct(Product product)
        {
            _db.CreateProduct(product.ProductDto);
            _db.AddOperation(new OperationDTO
            {
                ProductId = product.;
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public void RemoveCategory(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> SubCategories(Category category)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetOperations(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetOperations(DatePeriod period)
        {
            throw new NotImplementedException();
        }
    }
}