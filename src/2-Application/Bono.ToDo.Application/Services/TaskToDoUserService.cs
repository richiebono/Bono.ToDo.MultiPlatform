
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

namespace Bono.ToDo.Application.Services
{
    public class TaskToDoUserService : ITaskToDoUserService
    {

        private readonly ITaskToDoUserRepository TaskToDoUserRepository;
        private readonly IMapper mapper;
        private readonly ValidationResult validationResult;

        public TaskToDoUserService(ITaskToDoUserRepository TaskToDoUserRepository, IMapper mapper, ValidationResult validationResult)
        {
            this.TaskToDoUserRepository = TaskToDoUserRepository;
            this.mapper = mapper;
            this.validationResult = validationResult;
        }        

        public IEnumerable<TaskToDoUserViewModel> GetAll()
        {
            var TaskToDoUsers = this.TaskToDoUserRepository.GetAll();

            List<TaskToDoUserViewModel> _TaskToDoUserViewModels = mapper.Map<List<TaskToDoUserViewModel>>(TaskToDoUsers);

            return _TaskToDoUserViewModels;
        }

        public ValidationResult Post(TaskToDoUserViewModel TaskToDoUserViewModel)
        {
            if (TaskToDoUserViewModel.Id != Guid.Empty)
                validationResult.Add("ID must be empty");

            Validator.ValidateObject(TaskToDoUserViewModel, new ValidationContext(TaskToDoUserViewModel), true);

            TaskToDoUser TaskToDoUser = mapper.Map<TaskToDoUser>(TaskToDoUserViewModel);
            
            validationResult.Entity = this.TaskToDoUserRepository.Create(TaskToDoUser);

            if (validationResult.Entity == null)
            {
                validationResult.Add("The Entity you are trying to record is null, please try again!");
            }
            
            return validationResult;
            
        }

        public TaskToDoUserViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid TaskToDoUserId))
                throw new Exception("ID is not valid");

            TaskToDoUser _TaskToDoUser = this.TaskToDoUserRepository.Find(x => x.Id == TaskToDoUserId && !x.IsDeleted);
            if (_TaskToDoUser == null)
                throw new Exception("TaskToDoUser not found");

            return mapper.Map<TaskToDoUserViewModel>(_TaskToDoUser);
        }
        
        public IEnumerable<TaskToDoUserViewModel> GetByUserId(Guid id)
        {            

            TaskToDoUser _TaskToDoUser = this.TaskToDoUserRepository.Find(x => x.User.Id == id && !x.IsDeleted);
            if (_TaskToDoUser == null)
                throw new Exception("TaskToDoUser not found");

            return mapper.Map<IEnumerable<TaskToDoUserViewModel>>(_TaskToDoUser);
        }


        public ValidationResult Put(TaskToDoUserViewModel TaskToDoUserViewModel)
        {
            if (TaskToDoUserViewModel.Id == Guid.Empty)                
                validationResult.Add("ID is invalid");

            TaskToDoUser TaskToDoUser = this.TaskToDoUserRepository.Find(x => x.Id == TaskToDoUserViewModel.Id && !x.IsDeleted);
            if (TaskToDoUser == null)
                validationResult.Add("TaskToDoUser not found");
            
            TaskToDoUser = mapper.Map<TaskToDoUser>(TaskToDoUserViewModel);           
            
            try
            {
                this.TaskToDoUserRepository.Update(TaskToDoUser);
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }

            return validationResult;
        }

        public ValidationResult Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid TaskToDoUserId))
                validationResult.Add("ID is not valid");

            TaskToDoUser _TaskToDoUser = this.TaskToDoUserRepository.Find(x => x.Id == TaskToDoUserId && !x.IsDeleted);
            
            if (_TaskToDoUser == null)
                throw new Exception("TaskToDoUser not found");

            try
            {
                this.TaskToDoUserRepository.Delete(_TaskToDoUser);
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }
           
            return validationResult;

            
        }

        
    }
}
