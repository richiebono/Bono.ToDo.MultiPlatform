using System;
using System.Collections.Generic;
using Bono.ToDo.Data.Context;
using Bono.ToDo.Domain.Entities;
using Bono.ToDo.Domain.Interfaces.Repository;

namespace Bono.ToDo.Data.Repositories
{
    public class TaskToDoInviteRepository: Repository<TaskToDoInvite>, ITaskToDoInviteRepository
    {

        public TaskToDoInviteRepository(BonoToDoContext context)
            : base(context) { }

        public IEnumerable<TaskToDoInvite> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

    }
}
