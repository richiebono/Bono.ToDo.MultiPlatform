using System;
using System.Collections.Generic;
using Bono.ToDo.Data.Context;
using Bono.ToDo.Domain.Entities;
using Bono.ToDo.Domain.Interfaces.Repository;

namespace Bono.ToDo.Data.Repositories
{
    public class TaskToDoRepository: Repository<TaskToDo>, ITaskToDoRepository
    {

        public TaskToDoRepository(BonoToDoContext context)
            : base(context) { }

        public IEnumerable<TaskToDo> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

    }
}
