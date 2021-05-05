using System;
using System.Collections.Generic;
using Bono.ToDo.Data.Context;
using Bono.ToDo.Domain.Entities;
using Bono.ToDo.Domain.Interfaces.Repository;

namespace Bono.ToDo.Data.Repositories
{
    public class TaskToDoUserRepository: Repository<TaskToDoUser>, ITaskToDoUserRepository
    {

        public TaskToDoUserRepository(BonoToDoContext context)
            : base(context) { }

        public IEnumerable<TaskToDoUser> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

    }
}
