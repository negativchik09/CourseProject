using CourseProject.DB.Domain.Entities;

namespace CourseProject.DB.DTO
{
    public record ProductDTO
    {
        public int Id { get; init; }
        public string Articul { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }
        public int Count { get; init; }

        internal Product Product =>
            new Product
            {
                Amount = Count,
                Articul = Articul,
                Title = Title,
                Price = Price,
            };

        internal ProductDTO(Product product)
        {
            Count = product.Amount;
            Articul = product.Articul;
            Title = product.Title;
            Price = product.Price;
        }

        public ProductDTO() { }
    }
}
