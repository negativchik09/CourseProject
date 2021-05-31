namespace CourseProject.Interface.ViewModel
{
    public abstract record ViewModelBase
    {
        public int Id { get; init; }
        protected ViewModelBase() {}
    }
}
