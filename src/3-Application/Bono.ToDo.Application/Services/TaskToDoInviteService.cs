
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
    public class TaskToDoInviteService : ITaskToDoInviteService
    {

        private readonly ITaskToDoInviteRepository TaskToDoInviteRepository;
        private readonly IMapper mapper;
        private readonly ValidationResult validationResult;

        public TaskToDoInviteService(ITaskToDoInviteRepository TaskToDoInviteRepository, IMapper mapper, ValidationResult validationResult)
        {
            this.TaskToDoInviteRepository = TaskToDoInviteRepository;
            this.mapper = mapper;
            this.validationResult = validationResult;
        }        

        public IEnumerable<TaskToDoInviteViewModel> GetAll()
        {
            var TaskToDoInvites = this.TaskToDoInviteRepository.GetAll();

            List<TaskToDoInviteViewModel> _TaskToDoInviteViewModels = mapper.Map<List<TaskToDoInviteViewModel>>(TaskToDoInvites);

            return _TaskToDoInviteViewModels;
        }

        public ValidationResult Post(TaskToDoInviteViewModel TaskToDoInviteViewModel)
        {
            if (TaskToDoInviteViewModel.Id != Guid.Empty)
                validationResult.Add("ID must be empty");

            Validator.ValidateObject(TaskToDoInviteViewModel, new ValidationContext(TaskToDoInviteViewModel), true);

            TaskToDoInvite TaskToDoInvite = mapper.Map<TaskToDoInvite>(TaskToDoInviteViewModel);
            
            validationResult.Entity = this.TaskToDoInviteRepository.Create(TaskToDoInvite);

            if (validationResult.Entity == null)
            {
                validationResult.Add("The Entity you are trying to record is null, please try again!");
            }
            
            return validationResult;
            
        }

        public TaskToDoInviteViewModel GetById(string id)
        {
            if (!Guid.TryParse(id, out Guid TaskToDoInviteId))
                throw new Exception("ID is not valid");

            TaskToDoInvite _TaskToDoInvite = this.TaskToDoInviteRepository.Find(x => x.Id == TaskToDoInviteId && !x.IsDeleted);
            if (_TaskToDoInvite == null)
                throw new Exception("TaskToDoInvite not found");

            return mapper.Map<TaskToDoInviteViewModel>(_TaskToDoInvite);
        }

        public ValidationResult Put(TaskToDoInviteViewModel TaskToDoInviteViewModel)
        {
            if (TaskToDoInviteViewModel.Id == Guid.Empty)                
                validationResult.Add("ID is invalid");

            TaskToDoInvite TaskToDoInvite = this.TaskToDoInviteRepository.Find(x => x.Id == TaskToDoInviteViewModel.Id && !x.IsDeleted);
            if (TaskToDoInvite == null)
                validationResult.Add("TaskToDoInvite not found");
            
            TaskToDoInvite = mapper.Map<TaskToDoInvite>(TaskToDoInviteViewModel);           
            
            try
            {
                this.TaskToDoInviteRepository.Update(TaskToDoInvite);
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }

            return validationResult;
        }

        public ValidationResult Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid TaskToDoInviteId))
                validationResult.Add("TaskToDoInviteID is not valid");

            TaskToDoInvite _TaskToDoInvite = this.TaskToDoInviteRepository.Find(x => x.Id == TaskToDoInviteId && !x.IsDeleted);
            
            if (_TaskToDoInvite == null)
                throw new Exception("TaskToDoInvite not found");

            try
            {
                this.TaskToDoInviteRepository.Delete(_TaskToDoInvite);
            }
            catch (Exception ex)
            {
                validationResult.Add(ex.Message);
            }
           
            return validationResult;

            
        }

        public IEnumerable<TaskToDoInviteViewModel> GetByEmail(Guid taskId, string email)
        {
            TaskToDoInvite _TaskToDoInvite = this.TaskToDoInviteRepository.Find(x => x.Task.Id == taskId && x.Email == email && !x.IsDeleted);
            if (_TaskToDoInvite == null)
                throw new Exception("Invite not found");

            return mapper.Map<IEnumerable<TaskToDoInviteViewModel>>(_TaskToDoInvite);
        }
    }
}
