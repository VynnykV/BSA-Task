using System;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.Common.DTO.Task
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int PerformerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TaskState State { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}