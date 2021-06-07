
using Bono.ToDo.Domain.Entities;
using System.Collections.Generic;

namespace Bono.ToDo.Domain.Interfaces.Repository
{    
    public interface ITaskToDoUserRepository : IRepository<TaskToDoUser>
    {
        IEnumerable<TaskToDoUser> GetAll();
    }
}
