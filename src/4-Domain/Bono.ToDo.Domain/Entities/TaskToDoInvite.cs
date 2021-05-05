using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Models;

namespace Bono.ToDo.Domain.Entities
{
    public class TaskToDoInvite : Entity
    {   
        public string Email { get; private set; }
        public TaskToDo Task { get; private set; }
    }
}
