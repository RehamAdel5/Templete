using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string MainImagePath { get; set; }

        [ForeignKey("ProjectCategory")]
        public int ProjectCategoryId { get; set; }
        public ProjectCategory ProjectCategory { get; set; }
        public ICollection<ProjectImage> Images { get; set; }
    }
}
