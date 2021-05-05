using System.Collections.Generic;
using Bono.ToDo.Domain.Entities;

namespace Bono.ToDo.Domain.Interfaces.Repository
{

    public interface ITaskToDoInviteRepository : IRepository<TaskToDoInvite>
    {
        IEnumerable<TaskToDoInvite> GetAll();
    }
    
}
