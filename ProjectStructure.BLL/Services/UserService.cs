using System;
using System.Collections.Generic;
using AutoMapper;
using ProjectStructure.BLL.Exceptions;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.User;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public UserDTO AddUser(UserCreateDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            userEntity.RegisteredAt = DateTime.Now;
            _unitOfWork.UserRepository.Create(userEntity);
            return _mapper.Map<UserDTO>(userEntity);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<UserDTO>>(_unitOfWork.UserRepository.GetAll());
        }

        public UserDTO GetUserById(int id)
        {
            var userEntity = _unitOfWork.UserRepository.GetById(id);
            if (userEntity is null)
                throw new NotFoundException((nameof(User), id));
            return _mapper.Map<UserDTO>(userEntity);
        }

        public void UpdateUser(UserUpdateDTO user)
        {
            var userEntity = _mapper.Map<User>(user);
            if (_unitOfWork.UserRepository.GetById(user.Id) is null)
                throw new NotFoundException((nameof(User), user.Id));
            _unitOfWork.UserRepository.Update(userEntity);
        }

        public void DeleteUser(int id)
        {
            var userEntity = _unitOfWork.UserRepository.GetById(id);
            if (userEntity is null)
                throw new NotFoundException((nameof(User), id));
            _unitOfWork.UserRepository.Delete(id);
        }
    }
}