using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectStructure.Common.DTO.User;

namespace ProjectStructure.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> AddUser(UserCreateDTO user);
        Task<IEnumerable<UserDTO>> GetAll();
        Task<UserDTO> GetUserById(int id);
        Task UpdateUser(UserUpdateDTO user);
        Task DeleteUser(int id);
    }
}