using System.Collections.Generic;
using ProjectStructure.Common.DTO.User;

namespace ProjectStructure.BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO AddUser(UserCreateDTO user);
        IEnumerable<UserDTO> GetAll();
        UserDTO GetUserById(int id);
        void UpdateUser(UserDTO user);
        void DeleteUser(int id);
    }
}