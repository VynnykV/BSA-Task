using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectStructure.BLL.Exceptions;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.User;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ProjectStructure.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<UserDTO> AddUser(UserCreateDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            userEntity.RegisteredAt = DateTime.Now;
            await _unitOfWork.UserRepository.Create(userEntity);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task<IEnumerable<UserDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(await _unitOfWork.UserRepository.Query().ToListAsync());
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var userEntity = await _unitOfWork.UserRepository.GetById(id);
            if (userEntity is null)
                throw new NotFoundException((nameof(User), id));
            return _mapper.Map<UserDTO>(userEntity);
        }

        public async Task UpdateUser(UserUpdateDTO user)
        {
            var userEntity = await _unitOfWork.UserRepository.GetById(user.Id);
            if (userEntity is null)
                throw new NotFoundException((nameof(User), user.Id));
            userEntity.FirstName = user.FirstName;
            userEntity.LastName = user.LastName;
            userEntity.TeamId = user.TeamId;
            userEntity.BirthDay = user.BirthDay;
            userEntity.Email = user.Email;
            _unitOfWork.UserRepository.Update(userEntity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUser(int id)
        {
            var userEntity = await _unitOfWork.UserRepository.GetById(id);
            if (userEntity is null)
                throw new NotFoundException((nameof(User), id));
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}