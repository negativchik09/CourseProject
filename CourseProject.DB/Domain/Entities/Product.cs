using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DB.Domain.Entities
{
    internal class Product
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        [ForeignKey("Id")]
        public int CategoryId { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "money")]
        public decimal RecommendedPrice { get; set; }
        public int Amount { get; set; }
        public string Size { get; set; }
        public ForWho ForWho { get; set; }
        public string Material { get; set; }
        public string Brand { get; set; }
        public string Maker { get; set; }
        public string Description { get; set; }
        [MaxLength(4)]
        public string CollectionYear { get; set; }
    }
}