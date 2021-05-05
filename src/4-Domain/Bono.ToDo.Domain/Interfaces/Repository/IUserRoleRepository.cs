using System.Collections.Generic;
using Bono.ToDo.Domain.Entities;

namespace Bono.ToDo.Domain.Interfaces.Repository
{
    public interface IUserRoleRepository: IRepository<UserRole>
    {
        IEnumerable<UserRole> GetAll();
    }
}
