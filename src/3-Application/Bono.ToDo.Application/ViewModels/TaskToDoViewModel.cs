using Bono.ToDo.Infrastructure.Resources;
using System;
using System.ComponentModel.DataAnnotations;


namespace Bono.ToDo.Application.ViewModels
{
    public class TaskToDoViewModel: EntityViewModel
    {
        [Required]
        [Display(Name = "Title", ResourceType = typeof(Resources))]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Description", ResourceType = typeof(Resources))]
        public string Description { get; set; }
        [Display(Name = "TaskFather", ResourceType = typeof(Resources))]
        public Guid? TaskId { get; set; }
        public Guid? TaskFatherId { get; set; }
        [Display(Name = "IsDone", ResourceType = typeof(Resources))]
        public bool IsDone { get; set; }
        [Display(Name = "Invites", ResourceType = typeof(Resources))]
        public string[] Invites { get; set; }
        [Display(Name = "UserList", ResourceType = typeof(Resources))]
        public string[] UserList { get; set; }
        [Display(Name = "User", ResourceType = typeof(Resources))]
        public string UserId { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}
