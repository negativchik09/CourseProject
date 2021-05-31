using CourseProject.DB;
using CourseProject.Interface.Printers;

namespace CourseProject.Interface
{
    class Program
    {
        public static void Main(string[] args)
        {
            var controller = new Controller(DatabaseService.Instance, new ConsolePrinter());
            controller.Work();
        }
    }
}
