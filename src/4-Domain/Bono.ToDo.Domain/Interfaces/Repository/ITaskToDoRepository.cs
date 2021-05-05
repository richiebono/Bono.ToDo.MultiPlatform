using Bono.ToDo.Domain.Entities;
using System.Collections.Generic;

namespace Bono.ToDo.Domain.Interfaces.Repository
{
    public interface ITaskToDoRepository : IRepository<TaskToDo>
    {
        IEnumerable<TaskToDo> GetAll();
    }
}
