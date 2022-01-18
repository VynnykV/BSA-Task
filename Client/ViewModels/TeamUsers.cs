using System.Collections.Generic;

namespace Client.ViewModels
{
    public class TeamUsersDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
