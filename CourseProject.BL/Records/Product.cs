using System;
using CourseProject.DB.DTO;

namespace CourseProject.BL.Records
{
    public record Product
    {
        public string Articul { get; set; }
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string Size { get; set; }
        public string ForWho { get; set; }
        public string Material { get; set; }
        public string Brand { get; set; }
        public string Maker { get; set; }
        public string Description { get; set; }

        public string CollectionYear { get; set; }
        
        public int Margin { get; set; }

        internal ProductDTO ProductDto
        {
            get => new ProductDTO
              {
                  Articul = Articul,
                  Category = new CategoryDTO{Id = CategoryId, Title = CategoryTitle},
                  Title = Title,
                  Price = Price,
                  Count = Count,
                  Size = Size,
                  ForWho = ForWho switch
                  {
                      "Men" => DB.Domain.ForWho.Men,
                      "Woman" => DB.Domain.ForWho.Women,
                      "Unisex" => DB.Domain.ForWho.Unisex,
                      "Child" => DB.Domain.ForWho.Child,
                      _ => throw new ArgumentOutOfRangeException()
                  },
                  CollectionYear = CollectionYear,
                  Brand = Brand,
                  Description = Description,
                  Maker = Maker,
                  Material = Material
              };
        }

        internal Product(ProductDTO product)
        {
            Count = product.Count;
            Articul = product.Articul;
            Brand = product.Brand;
            CollectionYear = product.CollectionYear;
            Description = product.Description;
            ForWho = product.ForWho switch
            {
                DB.Domain.ForWho.Men => "Men",
                DB.Domain.ForWho.Women => "Woman",
                DB.Domain.ForWho.Unisex => "Unisex",
                DB.Domain.ForWho.Child => "Child",
                _ => throw new ArgumentOutOfRangeException()
            };
            Maker = product.Maker;
            Material = product.Material;
            Title = product.Title;
            Price = product.Price;
            Size = product.Size;
        }
    }
}