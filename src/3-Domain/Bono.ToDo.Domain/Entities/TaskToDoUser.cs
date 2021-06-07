using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Models;

namespace Bono.ToDo.Domain.Entities
{
    public class TaskToDoUser : Entity
    {        
        public TaskToDo Task { get; private set; }
        public User User { get; private set; }
    }
}
