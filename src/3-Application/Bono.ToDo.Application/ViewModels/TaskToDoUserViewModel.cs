using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Models;

namespace Bono.ToDo.Application.ViewModels
{
    public class TaskToDoUserViewModel : EntityViewModel
    {        
        public TaskToDoViewModel Task { get; private set; }
        public UserViewModel User { get; private set; }
    }
}
