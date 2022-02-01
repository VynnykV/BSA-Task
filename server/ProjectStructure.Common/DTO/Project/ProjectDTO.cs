using System;
using ProjectStructure.Common.DTO.Team;
using ProjectStructure.Common.DTO.User;

namespace ProjectStructure.Common.DTO.Project
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public UserDTO Author { get; set; }
        public TeamDTO Team { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}