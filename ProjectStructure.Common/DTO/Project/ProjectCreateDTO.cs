using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectStructure.Common.DTO.Project
{
    public class ProjectCreateDTO
    {
        public int AuthorId { get; set; }
        public int TeamId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}