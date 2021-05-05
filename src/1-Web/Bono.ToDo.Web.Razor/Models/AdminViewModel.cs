using Bono.ToDo.Infrastructure.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bono.ToDo.Web.Razor.Models
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        [Required]        
        [Display(Name = "RoleName", ResourceType = typeof(Resources))]
        public string Name { get; set; }
    }
}