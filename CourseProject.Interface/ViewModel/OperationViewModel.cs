using System;
using CourseProject.DB.Domain;
using CourseProject.DB.DTO;

namespace CourseProject.Interface.ViewModel
{
    public record OperationViewModel : ViewModelBase
    {
        public string ProductArticul { get; set; }
        public string Type { get; set; }
        public int CountDelta { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime DateTime { get; set; }

        public OperationViewModel(OperationDTO operationDto)
        {
            ProductArticul = operationDto.ProductArticul;
            Type = operationDto.Type switch
            {
                OperationType.Purchase => "Закупка",
                OperationType.Selling => "Продажа",
                OperationType.Dispose => "Списание",
                _ => throw new ArgumentOutOfRangeException()
            };
            CountDelta = operationDto.CountDelta;
            UnitPrice = operationDto.UnitPrice;
            DateTime = operationDto.DateTime; 
        }

        public override string ToString()
        {
            return $"{ProductArticul}, {Type}: {CountDelta} шт. по цене: {UnitPrice}. {DateTime}";
        }
    }
}