
using AutoMapper;
using System;
using System.Collections.Generic;
using Bono.ToDo.Application.Interfaces;
using Bono.ToDo.Application.ViewModels;
using Bono.ToDo.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
using ValidationResult = Bono.ToDo.Domain.Validations.ValidationResult;
using Bono.ToDo.Domain.Interfaces.Repository;
using Bono.ToDo.Domain.Interfaces.Business;
using System.Linq;

namespace Bono.ToDo.Application.Services
{
    public class TaskToDoService : ITaskToDoService
    {

        private readonly ITaskToDoRepository taskToDoRepository;

        private readonly IUserService userService;        
        private readonly ITaskToDoUserService taskUserService;
        private readonly ITaskToDoInviteService taskInviteService;
        private readonly IEmailManager emailManager;

        private readonly IMapper mapper;
        private readonly ValidationResult validationResult;

        public TaskToDoService(ITaskToDoRepository taskToDoRepository, IMapper mapper, ValidationResult validationResult)
        {
            this.taskToDoRepository = taskToDoRepository;
            this.mapper = mapper;
            this.validationResult = validationResult;
        }        

        public ValidationResult Post(TaskToDoViewModel TaskToDoViewModel)
        {
            if (TaskToDoViewModel.Id != Guid.Empty)
                validationResult.Add("ID must be empty");

            Validator.ValidateObject(TaskToDoViewModel, new ValidationContext(TaskToDoViewModel), true);

            TaskToDo TaskToDo = mapper.Map<TaskToDo>(TaskToDoViewModel);
            
            validationResult.Entity = this.taskToDoRepository.Create(TaskToDo);

            if (validationResult.Entity == null)
            {
                validationResult.Add("The Entity you are trying to record is null, please try again!");
            }
            
            return validationResult;
            
        }

        public ValidationResult Put(TaskToDoViewModel TaskToDoViewModel)
        {
            if (TaskToDoViewModel.Id == Guid.Empty)
                validationResult.Add("ID is invalid");

            TaskToDo TaskToDo = this.taskToDoRepository.Find(x => x.Id == TaskToDoViewModel.Id && !x.IsDeleted);
            if (TaskToDo == null)
                validationResult.Add("TaskToDo not found");

            TaskToDo = mapper.Map<TaskToDo>(TaskToDoViewModel);

            try
            {
                this.taskToDoRepository.Update(TaskToDo);
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }

            return validationResult;
        }

        public ValidationResult Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid TaskToDoId))
                validationResult.Add("ID is not valid");

            TaskToDo _TaskToDo = this.taskToDoRepository.Find(x => x.Id == TaskToDoId && !x.IsDeleted);

            if (_TaskToDo == null)
                throw new Exception("TaskToDo not found");

            try
            {
                this.taskToDoRepository.Delete(_TaskToDo);
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }

            return validationResult;


        }

        public IEnumerable<TaskToDoViewModel> GetSubTasksByUser(string userId, Guid taskId)
        {
            if (!Guid.TryParse(userId, out Guid UserId))
                throw new Exception("UserID is not valid");

            var tasks = this.taskToDoRepository.Query(x => x.User.Id == UserId && x.TaskFather.Id == taskId).ToList();

            var user = userService.GetById(userId);

            var taskInvite = this.taskInviteService.GetByEmail(taskId, user.Email);

            foreach (var item in taskInvite)
            {
                var tasksEmail = this.taskToDoRepository.Query(x => x.User.Id == user.Id && x.TaskFather.Id == item.Id).ToList();
                foreach (var taskEmail in tasksEmail)
                {
                    if (tasks.Where(x => x.Id == taskEmail.Id).Count() == 0)
                    {
                        tasks.Add(taskEmail);
                    }
                }
            }

            var tasksUsers = this.taskUserService.GetByUserId(taskId);

            foreach (var item in tasksUsers)
            {
                var tasksUser = this.taskToDoRepository.Query(x => x.User.Id == item.User.Id && x.TaskFather.Id == item.Task.TaskId).ToList();
                foreach (var taskUser in tasksUser)
                {
                    if (tasks.Where(x => x.Id == taskUser.Id).Count() == 0)
                    {
                        tasks.Add(taskUser);
                    }
                }
            }

            return mapper.Map<List<TaskToDoViewModel>>(tasks);

        }

        public IEnumerable<TaskToDoViewModel> GetAll()
        {
            var TaskToDos = this.taskToDoRepository.GetAll();

            List<TaskToDoViewModel> _TaskToDoViewModels = mapper.Map<List<TaskToDoViewModel>>(TaskToDos);

            return _TaskToDoViewModels;
        }

        public TaskToDoViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid TaskToDoId))
                throw new Exception("ID is not valid");

            TaskToDo _TaskToDo = this.taskToDoRepository.Find(x => x.Id == TaskToDoId && !x.IsDeleted);
            if (_TaskToDo == null)
                throw new Exception("TaskToDo not found");

            return mapper.Map<TaskToDoViewModel>(_TaskToDo);
        }

        public IEnumerable<TaskToDoViewModel> GetAll(Guid? userId)
        {
            var TaskToDos = this.taskToDoRepository.Query(x=> x.User.Id == userId);

            List<TaskToDoViewModel> _TaskToDoViewModels = mapper.Map<List<TaskToDoViewModel>>(TaskToDos);

            return _TaskToDoViewModels;
        }
    }
}
