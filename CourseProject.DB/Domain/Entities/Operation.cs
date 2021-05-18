using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DB.Domain.Entities
{
    public class Operation
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int ProductId { get; set; }
        public OperationType Type { get; set; }
        public int CountDelta { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime DateTime { get; set; }
    }
}