using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Timers;
using CourseProject.BL.Enums;
using CourseProject.BL.Records;

namespace CourseProject.BL.Interface
{
    public interface IStoreService
    {
        public void CreateProduct(Product product);
        public IEnumerable<Product> GetProducts();
        public IEnumerable<Product> GetProductsByCategory(int categoryId);
        public void AddProduct(Product product);
        public void UpdateProduct(Product product);
        public void RemoveProduct(Product product);
        public void DeleteProduct(Product product);
        public void CreateCategory(Category category);
        public void RemoveCategory(Category category);
        public IEnumerable<Category> SubCategories(Category category);
        public IEnumerable<Operation> GetOperations(Product product);
        public IEnumerable<Operation> GetOperations(DatePeriod period);
    }
}