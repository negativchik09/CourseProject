using System;
using System.Linq;
using CourseProject.Interface.Enums;
using CourseProject.Interface.Printers;
using CourseProject.DB;
using CourseProject.DB.Domain;
using CourseProject.DB.DTO;
using CourseProject.Interface.ViewModel;
using static CourseProject.Interface.Enums.ApplicationState;
using static CourseProject.Interface.Enums.Command;

namespace CourseProject.Interface
{
    public class Controller
    {
        private readonly IDatabaseService _db;
        private readonly IPrinter _printer;

        public Controller(IDatabaseService db, IPrinter printer)
        {
            _db = db;
            _printer = printer;
        }

        public void Work()
        {
            var state = Products;
            while (true)
            {
                _printer.Reset();
                _printer.PrintHeader(); 
                switch (state)
                {
                    case Products:
                        _printer.PrintMainScreen(_db.GetProducts().Select(x => new ProductViewModel(x)));
                        break;
                    case Operations:
                        _printer.PrintMainScreen(_db.GetOperations().Select(x => new OperationViewModel(x)));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                switch (_printer.GetCommand())
                {
                    case CreateProduct:
                        var modelCreating = _printer.GetData(TakeDataType.CreateProduct) as ProductViewModel;
                        _db.CreateProduct(modelCreating.ProductDto).Wait();
                        _db.AddOperation(new OperationDTO
                        {
                            ProductArticul = modelCreating.Articul,
                            Type = OperationType.Purchase,
                            CountDelta = modelCreating.Count,
                            UnitPrice = modelCreating.Price,
                        }).Wait();
                        break;
                    case AddProduct:
                        var modelAdding = _printer.GetData(TakeDataType.AddProduct) as ProductViewModel;
                        _db.AddProduct(modelAdding.ProductDto).Wait();
                        _db.AddOperation(new OperationDTO
                        {
                            ProductArticul = modelAdding.Articul,
                            Type = OperationType.Purchase,
                            CountDelta = modelAdding.Count,
                            UnitPrice = modelAdding.Price,
                        }).Wait();
                        break;
                    case ShowProducts:
                        state = Products;
                        break;
                    case DisposeProduct:
                        var modelDisposing = _printer.GetData(TakeDataType.DisposeProduct) as ProductViewModel;
                        _db.RemoveProducts(modelDisposing.ProductDto).Wait();
                        _db.AddOperation(new OperationDTO
                        {
                            ProductArticul = modelDisposing.Articul,
                            UnitPrice = 0,
                            CountDelta = modelDisposing.Count,
                            Type = OperationType.Dispose
                        }).Wait();
                        break;
                    case SellProduct:
                        var modelSelling = _printer.GetData(TakeDataType.SellProduct) as ProductViewModel;
                        _db.RemoveProducts(modelSelling.ProductDto).Wait();
                        _db.AddOperation(new OperationDTO
                        {
                            ProductArticul = modelSelling.Articul,
                            UnitPrice = modelSelling.SellingPrice,
                            CountDelta = modelSelling.Count,
                            Type = OperationType.Dispose
                        }).Wait();
                        break;
                    case ShowOperations:
                        state = Operations;
                        break;
                    case Refresh:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}