using System;

namespace ProjectStructure.DAL.Entities
{
    public class Task : BaseEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int PerformerId { get; set; }
        public User Performer { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}