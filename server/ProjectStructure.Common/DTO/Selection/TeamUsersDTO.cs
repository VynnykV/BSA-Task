using System.Collections.Generic;
using ProjectStructure.Common.DTO.User;

namespace ProjectStructure.Common.DTO.Selection
{
    public class TeamUsersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserDTO> Users { get; set; }
    }
}