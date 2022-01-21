using System.ComponentModel.DataAnnotations;

namespace ProjectStructure.Common.DTO.Team
{
    public class TeamCreateDTO
    {
        [Required]
        public string Name { get; set; }
    }
}