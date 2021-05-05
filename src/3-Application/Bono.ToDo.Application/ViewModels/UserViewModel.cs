using Bono.ToDo.Infrastructure.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bono.ToDo.Application.ViewModels
{
    public class UserViewModel: EntityViewModel
    {
        [Display(Name = "Cpf", ResourceType = typeof(Resources))]
        public string Cpf { get; set; }
        
        [DataType(DataType.EmailAddress, ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "StringLengthPasswordError", ErrorMessageResourceType = typeof(Resources), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources))]
        [Compare("Password", ErrorMessageResourceName = "PasswordConfirmationError", ErrorMessageResourceType = typeof(Resources))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(Resources))]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resources))]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Resources))]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "LastName", ResourceType = typeof(Resources))]
        public string LastName { get; set; }


        public string Discriminator { get; set; }        
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        
        public string SecurityStamp { get; set; }




    }
}
