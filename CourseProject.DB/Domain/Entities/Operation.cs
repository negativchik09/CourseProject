using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DB.Domain.Entities
{
    internal class Operation
    {
        public int Id { get; set; }
        [ForeignKey("Articul")]
        public string ProductArticul { get; set; }
        public OperationType Type { get; set; }
        public int CountDelta { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime DateTime { get; set; }
    }
}
