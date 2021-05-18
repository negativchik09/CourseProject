using System;
using CourseProject.DB.Domain;
using CourseProject.DB.Domain.Entities;

namespace CourseProject.DB.DTO
{
    public record OperationDTO
    {
        public int Id { get; init; }
        public int ProductId { get; init; }
        public OperationType Type { get; init; }
        public int CountDelta { get; init; }
        public decimal UnitPrice { get; init; }
        public DateTime DateTime { get; init; }

        internal Operation Operation =>
            new Operation
            {
                Id = Id,
                ProductId = ProductId,
                Type = Type,
                CountDelta = CountDelta,
                DateTime = DateTime,
                UnitPrice = UnitPrice
            };

        internal OperationDTO(Operation operation)
        {
            Id = operation.Id;
            ProductId = operation.ProductId;
            Type = operation.Type;
            CountDelta = operation.CountDelta;
            DateTime = operation.DateTime;
            UnitPrice = operation.UnitPrice;
        }
    }
}