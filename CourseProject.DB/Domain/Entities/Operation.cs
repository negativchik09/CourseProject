using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DB.Domain.Entities
{
    public class Operation
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int ProductId { get; set; }
        public OperationType Type { get; set; }
    }
}