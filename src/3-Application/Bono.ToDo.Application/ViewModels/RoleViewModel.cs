using Bono.ToDo.Infrastructure.Resources;
using System;
using System.ComponentModel.DataAnnotations;


namespace Bono.ToDo.Application.ViewModels
{
    public class RoleViewModel: EntityViewModel
    {
        [Required]
        [Display(Name = "RoleName", ResourceType = typeof(Resources))]
        public string Name { get; set; }        
    }
}
