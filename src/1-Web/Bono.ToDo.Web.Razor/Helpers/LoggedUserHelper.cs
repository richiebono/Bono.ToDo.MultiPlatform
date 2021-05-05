using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Bono.ToDo.Web.Razor.Helpers
{
    public class LoggedUserHelper : ClaimsPrincipal
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public LoggedUserHelper(ClaimsPrincipal user)
        {
            Thread.CurrentPrincipal = user;
            this.AddIdentities(user.Identities);            
        }

        public string Name
        {
            get
            {
                return this.GetClaimValue(ClaimTypes.Name);
            }            
        }

        public string Email
        {
            get
            {
                return this.GetClaimValue(ClaimTypes.Email);
            }
        }

        public Guid ? UserId
        {
            get
            {
                if(!string.IsNullOrEmpty(this.GetClaimValue(ClaimTypes.NameIdentifier)))
                {
                    return new Guid(this.GetClaimValue(ClaimTypes.NameIdentifier));
                }
                else
                {
                    return null;
                }
                
            }
        }

        /// <summary>
        /// Get Claim Value
        /// </summary>
        /// <param name="key">Claim Key</param>
        /// <returns>System.String</returns>
        private string GetClaimValue(string key)
        {
            var identity = this.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            if (identity.Claims == null)
                return null;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == key);

            if (claim == null)
                return null;

            return claim.Value;
        }


    }
}
