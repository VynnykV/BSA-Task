using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class UserWithTasksDTO
    {
        public User User { get; set; }
        public IEnumerable<Task> Tasks { get; set; }
    }
}
