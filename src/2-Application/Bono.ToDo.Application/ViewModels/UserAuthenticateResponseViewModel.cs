using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Entities;

namespace Bono.ToDo.Application.ViewModels
{
    public class UserAuthenticateResponseViewModel
    {
        public UserAuthenticateResponseViewModel(UserViewModel user, string token)
        {
            this.User = user;
            this.Token = token;
        }

        public UserViewModel User { get; set; }
        public string Token { get; set; }
    }
}
