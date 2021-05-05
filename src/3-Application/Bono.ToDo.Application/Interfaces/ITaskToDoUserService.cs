using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Application.ViewModels;

namespace Bono.ToDo.Application.Interfaces
{
    public interface ITaskToDoUserService : IService<TaskToDoUserViewModel>
    {
        IEnumerable<TaskToDoUserViewModel> GetByUserId(Guid taskId);
    }
}
