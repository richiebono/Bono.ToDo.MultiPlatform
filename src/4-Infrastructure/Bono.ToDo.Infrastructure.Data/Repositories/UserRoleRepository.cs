using System;
using System.Collections.Generic;
using Bono.ToDo.Data.Context;
using Bono.ToDo.Domain.Entities;
using Bono.ToDo.Domain.Interfaces.Repository;

namespace Bono.ToDo.Data.Repositories
{
    public class UserRoleRepository: Repository<UserRole>, IUserRoleRepository
    {

        public UserRoleRepository(BonoToDoContext context)
            : base(context) { }

        public IEnumerable<UserRole> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

    }
}
