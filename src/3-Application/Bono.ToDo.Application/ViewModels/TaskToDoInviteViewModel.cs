using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Models;

namespace Bono.ToDo.Application.ViewModels
{
    public class TaskToDoInviteViewModel : EntityViewModel
    {   
        public string Email { get; private set; }
        public TaskToDoViewModel Task { get; private set; }
    }
}
