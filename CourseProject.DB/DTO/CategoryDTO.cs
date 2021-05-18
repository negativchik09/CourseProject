using System.Collections.Generic;
using CourseProject.DB.Domain.Entities;

namespace CourseProject.DB.DTO
{
    public record CategoryDTO
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public int ParentId { get; init; }

        internal Category Category =>
            new Category
            {
                Id = Id,
                Title = Title,
                ParentId = ParentId
            };

        internal CategoryDTO(Category category)
        {
            Id = category.Id;
            Title = category.Title;
            ParentId = category.ParentId;
        }
    }
}