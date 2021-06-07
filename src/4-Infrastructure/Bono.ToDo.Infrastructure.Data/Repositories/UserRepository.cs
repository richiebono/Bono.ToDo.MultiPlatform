using System.Collections.Generic;
using Bono.ToDo.Data.Context;
using Bono.ToDo.Domain.Entities;
using Bono.ToDo.Domain.Interfaces.Repository;

namespace Bono.ToDo.Data.Repositories
{
    public class UserRepository: Repository<User>, IUserRepository
    {

        public UserRepository(BonoToDoContext context)
            : base(context) { }

        public IEnumerable<User> GetAll()
        {
            return Query(x => !x.IsDeleted);
        }

    }
}
