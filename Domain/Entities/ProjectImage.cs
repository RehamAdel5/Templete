﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ProjectImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
