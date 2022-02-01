using System;
using ProjectStructure.DAL.Entities;

namespace ProjectStructure.Common.DTO.Task
{
    public class TaskUpdateDTO
    {
        public int Id { get; set; }
        public int PerformerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}