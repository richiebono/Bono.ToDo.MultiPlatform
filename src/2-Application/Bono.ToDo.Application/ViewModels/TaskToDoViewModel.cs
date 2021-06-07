using System;
using System.ComponentModel.DataAnnotations;


namespace Bono.ToDo.Application.ViewModels
{
    public class TaskToDoViewModel: EntityViewModel
    {
        [Required]        
        public string Title { get; set; }
        
        [Required]
        
        public string Description { get; set; }
        
        public Guid? TaskId { get; set; }
        public Guid? TaskFatherId { get; set; }
        
        public bool IsDone { get; set; }
        
        public string[] Invites { get; set; }
        
        public string[] UserList { get; set; }
        
        public string UserId { get; set; }
        
    }
}
