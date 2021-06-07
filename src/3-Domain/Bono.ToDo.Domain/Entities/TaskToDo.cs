using System;
using System.Collections.Generic;
using System.Text;
using Bono.ToDo.Domain.Models;

namespace Bono.ToDo.Domain.Entities
{
    public class TaskToDo : Entity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsDone { get; private set; }        
        public int Sort { get; private set; }
        public TaskToDo TaskFather { get; private set; }
        public User User { get; private set; }
    }
}
