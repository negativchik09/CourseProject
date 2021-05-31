using System.Collections.Generic;
using CourseProject.Interface.Enums;
using CourseProject.Interface.ViewModel;

namespace CourseProject.Interface.Printers
{
    public interface IPrinter
    {
        public void PrintHeader();
        public void PrintMainScreen(IEnumerable<ViewModelBase> model);
        public ViewModelBase GetData(TakeDataType type);
        public Command GetCommand();
        public void Reset();
    }
}