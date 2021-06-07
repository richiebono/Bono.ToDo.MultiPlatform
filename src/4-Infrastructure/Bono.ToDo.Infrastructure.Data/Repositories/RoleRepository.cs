using System;
using System.Collections.Generic;
using Bono.ToDo.Data.Context;
using Bono.ToDo.Domain.Entities;
using Bono.ToDo.Domain.Interfaces.Repository;

namespace Bono.ToDo.Data.Repositories
{
    public class RoleRepository: Repository<Role>, IRoleRepository
    {

        public RoleRepository(BonoToDoContext context)
            : base(context) { }

        public IEnumerable<Role> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

    }
}
