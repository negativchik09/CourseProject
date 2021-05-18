using System;
using System.Text.RegularExpressions;
using CourseProject.DB.Domain;
using CourseProject.DB.Domain.Entities;

namespace CourseProject.DB.DTO
{
    public record ProductDTO
    {
        public int Id { get; internal init; }
        public string Articul { get; init; }
        public CategoryDTO Category { get; init; }
        public string Title { get; init; }
        public decimal Price { get; init; }
        public int Count { get; init; }
        public string Size { get; init; }
        public ForWho ForWho { get; init; }
        public string Material { get; init; }
        public string Brand { get; init; }
        public string Maker { get; init; }
        public string Description { get; init; }
        private string _collectionYear;

        public string CollectionYear
        {
            get => _collectionYear;
            init
            {
                if (Regex.IsMatch(value, @"\d{4}"))
                {
                    _collectionYear = value;
                }

                throw new ArgumentException("Not valid year");
            }
        }

        internal Product Product =>
            new Product
            {
                Amount = Count,
                Articul = Articul,
                Brand = Brand,
                CategoryId = Category.Id,
                CollectionYear = CollectionYear,
                Description = Description,
                ForWho = ForWho,
                Maker = Maker,
                Material = Material,
                Title = Title,
                RecommendedPrice = Price,
                Size = Size
            };

        internal ProductDTO(Product product)
        {
            Count = product.Amount;
            Articul = product.Articul;
            Brand = product.Brand;
            CollectionYear = product.CollectionYear;
            Description = product.Description;
            ForWho = product.ForWho;
            Maker = product.Maker;
            Material = product.Material;
            Title = product.Title;
            Price = product.RecommendedPrice;
            Size = product.Size;
        }
    }
}