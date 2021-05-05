using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Application.ViewModels;

namespace Bono.ToDo.Application.Interfaces
{
    public interface ITaskToDoInviteService : IService<TaskToDoInviteViewModel>
    {
        IEnumerable<TaskToDoInviteViewModel> GetByEmail(Guid taskId, string email);
    }
}
