using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DB.Domain.Entities
{
    internal class Product
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Title { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
