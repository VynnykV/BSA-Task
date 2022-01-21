using System;
using System.Collections.Generic;
using AutoMapper;
using ProjectStructure.BLL.Exceptions;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.Task;
using ProjectStructure.DAL.Entities;
using ProjectStructure.DAL.Interfaces;

namespace ProjectStructure.BLL.Services
{
    public class TaskService : BaseService, ITaskService
    {
        public TaskService(
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public TaskDTO AddTask(TaskCreateDTO task)
        {
            var taskEntity = _mapper.Map<Task>(task);
            taskEntity.CreatedAt = DateTime.Now;
            _unitOfWork.TaskRepository.Create(taskEntity);
            _unitOfWork.SaveChanges();
            return _mapper.Map<TaskDTO>(taskEntity);
        }

        public IEnumerable<TaskDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<TaskDTO>>(_unitOfWork.TaskRepository.GetAll());
        }

        public TaskDTO GetTaskById(int id)
        {
            var taskEntity = _unitOfWork.TaskRepository.GetById(id);
            if (taskEntity is null)
                throw new NotFoundException(nameof(Task), id);
            return _mapper.Map<TaskDTO>(taskEntity);
        }

        public void UpdateTask(TaskUpdateDTO task)
        {
            var taskEntity = _mapper.Map<Task>(task);
            if (_unitOfWork.TaskRepository.GetById(task.Id) is null)
                throw new NotFoundException((nameof(Task), task.Id));
            _unitOfWork.TaskRepository.Update(taskEntity);
            _unitOfWork.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var taskEntity = _unitOfWork.TaskRepository.GetById(id);
            if (taskEntity is null)
                throw new NotFoundException(nameof(Task), id);
            _unitOfWork.TaskRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}