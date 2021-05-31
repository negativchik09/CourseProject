using System.Collections.Generic;
using System.Threading.Tasks;
using CourseProject.DB.DTO;

namespace CourseProject.DB
{
    public interface IDatabaseService
    {
        public Task CreateProduct(ProductDTO product);

        public IEnumerable<ProductDTO> GetProducts();

        public Task AddProduct(ProductDTO product);

        public Task UpdateProduct(ProductDTO product);

        public Task RemoveProducts(ProductDTO product);

        public Task DeleteProduct(ProductDTO productDto);

        public IEnumerable<OperationDTO> GetOperations();

        public Task AddOperation(OperationDTO operation);
    }
}
