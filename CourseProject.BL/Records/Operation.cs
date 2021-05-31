using System;
using CourseProject.DB.Domain;

namespace CourseProject.BL.Records
{
    public record Operation
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public OperationType Type { get; set; }
        public int CountDelta { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime DateTime { get; set; }
    }
}