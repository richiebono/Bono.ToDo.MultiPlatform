using Bono.ToDo.Infrastructure.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bono.ToDo.Web.Razor.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resources))]
        public string UserName { get; set; }

        [Required]
        public string LoginProvider { get; set; }
    }

    public class UserAuthenticateRequestViewModel
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password", ResourceType = typeof(Resources))]
        public string Password { get; set; }

    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]        
        [Display(Name = "OldPassword", ResourceType = typeof(Resources))]
        public string OldPassword { get; set; }

        [Required]        
        [StringLength(100, ErrorMessageResourceName = "StringLengthPasswordError", ErrorMessageResourceType = typeof(Resources), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "NewPassword", ResourceType = typeof(Resources))]       
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources))]
        [Compare("NewPassword", ErrorMessageResourceName = "PasswordConfirmationError", ErrorMessageResourceType = typeof(Resources))]
        public string ConfirmPassword { get; set; }
    }

    public class RegisterViewModel
    {
        public Guid ? Id { get; set; }

        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resources))]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Resources))]        
        public string FirstName { get; set; }

        [Required]        
        [Display(Name = "LastName", ResourceType = typeof(Resources))]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = "StringLengthPasswordError", ErrorMessageResourceType = typeof(Resources), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resources))]
        [Compare("Password", ErrorMessageResourceName = "PasswordConfirmationError", ErrorMessageResourceType = typeof(Resources))]
        public string ConfirmPassword { get; set; }

        [Display(Name = "HomeTown", ResourceType = typeof(Resources))]
        public string HomeTown { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(Resources))]
        [Display(Name = "Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }
        [Display(Name = "Cpf", ResourceType = typeof(Resources))]
        public string Cpf { get; set; }
        [Display(Name = "PhoneNumber", ResourceType = typeof(Resources))]
        [DataType(DataType.PhoneNumber, ErrorMessageResourceName = "InvalidPhoneNumber", ErrorMessageResourceType = typeof(Resources))]
        public string PhoneNumber { get; set; }

    }

    public class UserViewModel
    {
        public Guid Id { get; set; }

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
