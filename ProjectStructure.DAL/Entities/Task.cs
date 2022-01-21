using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectStructure.DAL.Entities
{
    public class Task : BaseEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int PerformerId { get; set; }
        public User Performer { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public TaskState State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}