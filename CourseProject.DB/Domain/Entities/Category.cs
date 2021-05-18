namespace CourseProject.DB.Domain.Entities
{
    internal class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
    }
}