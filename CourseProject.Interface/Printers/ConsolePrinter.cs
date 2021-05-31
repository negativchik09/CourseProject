using System;
using System.Collections.Generic;
using CourseProject.Interface.Enums;
using CourseProject.Interface.ViewModel;

namespace CourseProject.Interface.Printers
{
    public class ConsolePrinter : IPrinter
    {
        public void PrintHeader()
        {
            Console.WriteLine(
                $"{"1 - Добавить новый вид товара",-40}║ {"2 - Завезти партию существующего товара",-40}║ {"3 - Списать товар",-40}");
            PrintSeparator();
            Console.WriteLine(
                $"{"4 - Продажа товара",-40}║ {"5 - Показать все товары",-40}║ {"6 - Показать историю транзакций",-40}");
            PrintSeparator();
        }

        public void PrintMainScreen(IEnumerable<ViewModelBase> model)
        {
            foreach (var element in model)
            {
                Console.WriteLine(element);
            }
        }

        public ViewModelBase GetData(TakeDataType type)
        {
            string buffer;
            var model = new ProductViewModel();
            switch (type)
            {
                case TakeDataType.CreateProduct:
                    Console.WriteLine("Введите артикул товара");
                    model.Articul = Console.ReadLine();
                    Console.WriteLine("Введите название товара");
                    model.Title = Console.ReadLine();
                    Console.WriteLine("Введите закупочную цену товара");
                    model.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Введите рыночную цену товара");
                    model.SellingPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Введите количество товара");
                    model.Count = Convert.ToInt32(Console.ReadLine());
                    break;
                case TakeDataType.AddProduct:
                    Console.WriteLine("Введите артикул товара");
                    model.Articul = Console.ReadLine();
                    Console.WriteLine("Введите закупочную цену товара");
                    model.Price = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Введите количество товара");
                    model.Count = Convert.ToInt32(Console.ReadLine());
                    break;
                case TakeDataType.UpdateProduct:
                    Console.WriteLine("Введите артикул товара");
                    model.Articul = Console.ReadLine();
                    Console.WriteLine("Введите название товара");
                    model.Title = Console.ReadLine();
                    Console.WriteLine("Введите рыночную цену товара");
                    model.SellingPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Введите количество товара");
                    model.Count = Convert.ToInt32(Console.ReadLine());
                    break;
                case TakeDataType.SellProduct:
                    Console.WriteLine("Введите артикул товара");
                    model.Articul = Console.ReadLine();
                    Console.WriteLine("Введите рыночную цену товара");
                    model.SellingPrice = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Введите количество товара");
                    model.Count = Convert.ToInt32(Console.ReadLine());
                    break;
                case TakeDataType.DisposeProduct:
                    Console.WriteLine("Введите артикул товара");
                    model.Articul = Console.ReadLine();
                    Console.WriteLine("Введите количество товара");
                    model.Count = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            return model;
        }

        public Command GetCommand()
        {
            return Console.ReadKey(true).Key switch
            {
                ConsoleKey.D1 => Command.CreateProduct,
                ConsoleKey.D2 => Command.AddProduct,
                ConsoleKey.D3 => Command.DisposeProduct,
                ConsoleKey.D4 => Command.SellProduct,
                ConsoleKey.D5 => Command.ShowProducts,
                ConsoleKey.D6 => Command.ShowOperations,
                _ => Command.Refresh,
            };
        }

        public void Reset()
        {
            Console.Clear();
        }
        
        private void PrintSeparator()
        {
            for (int i = 0; i < 125; i++)
            {
                if (i == 40 || i == 82)
                {
                    Console.Write("╬");
                    continue;
                }
                Console.Write("=");
            }
            Console.WriteLine();
        }
    }
}