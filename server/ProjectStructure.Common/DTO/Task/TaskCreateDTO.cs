using System.ComponentModel.DataAnnotations;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.Common.DTO.Task
{
    public class TaskCreateDTO
    {
        public int ProjectId { get; set; }
        public int PerformerId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}