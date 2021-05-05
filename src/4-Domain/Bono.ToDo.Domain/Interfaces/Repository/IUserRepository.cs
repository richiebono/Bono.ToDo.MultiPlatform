using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Entities;

namespace Bono.ToDo.Domain.Interfaces.Repository
{
    public interface IUserRepository: IRepository<User>
    {
        IEnumerable<User> GetAll();
    }
}
