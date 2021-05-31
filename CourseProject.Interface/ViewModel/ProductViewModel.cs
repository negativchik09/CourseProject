using CourseProject.DB.DTO;

namespace CourseProject.Interface.ViewModel
{
    public record ProductViewModel : ViewModelBase
    {
        public string Articul { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal SellingPrice { get; set; }
        public int Count { get; set; }

        public ProductViewModel(ProductDTO product)
        {
            Id = product.Id;
            Articul = product.Articul;
            Title = product.Title;
            SellingPrice = product.Price;
            Count = product.Count;
        }

        internal ProductDTO ProductDto =>
            new ProductDTO
            {
                Articul = Articul,
                Title = Title,
                Count = Count,
                Price = SellingPrice
            };

        public ProductViewModel() : base() { }

        public override string ToString()
        {
            return $"{Articul}, {Title}, цена: {SellingPrice: f2}, остаток: {Count}";
        }
    }
}
