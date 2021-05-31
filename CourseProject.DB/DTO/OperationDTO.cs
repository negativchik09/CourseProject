using System;
using CourseProject.DB.Domain;
using CourseProject.DB.Domain.Entities;

namespace CourseProject.DB.DTO
{
    public record OperationDTO
    {
        public int Id { get; init; }
        public string ProductArticul { get; init; }
        public OperationType Type { get; init; }
        public int CountDelta { get; init; }
        public decimal UnitPrice { get; init; }
        public DateTime DateTime { get; }

        internal Operation Operation =>
            new Operation
            {
                Id = Id,
                ProductArticul = ProductArticul,
                Type = Type,
                CountDelta = CountDelta,
                DateTime = DateTime,
                UnitPrice = UnitPrice
            };

        internal OperationDTO(Operation operation)
        {
            Id = operation.Id;
            ProductArticul = operation.ProductArticul;
            Type = operation.Type;
            CountDelta = operation.CountDelta;
            DateTime = operation.DateTime;
            UnitPrice = operation.UnitPrice;
        }

        public OperationDTO()
        {
            DateTime = DateTime.Now;
        }
    }
}
