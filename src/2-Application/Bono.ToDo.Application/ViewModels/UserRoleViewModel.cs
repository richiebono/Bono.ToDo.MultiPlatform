using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Models;

namespace Bono.ToDo.Application.ViewModels
{
    public class UserRoleViewModel : EntityViewModel
    {
        public UserViewModel User { get; private set; }
        public RoleViewModel Role { get; private set; }
    }
}
