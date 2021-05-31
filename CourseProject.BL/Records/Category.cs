using CourseProject.DB.DTO;

namespace CourseProject.BL.Records
{
    public record Category
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public int ParentId { get; init; }

        internal Category(CategoryDTO category)
        {
            Id = category.Id;
            Title = category.Title;
            ParentId = category.ParentId;
        }
    }
}