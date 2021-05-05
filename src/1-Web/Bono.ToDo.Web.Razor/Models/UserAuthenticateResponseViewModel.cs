using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bono.ToDo.Web.Razor.Models
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
