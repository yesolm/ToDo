using System;

namespace ToDo.Core.Models
{
    public class ToDoTask
    {
        public int Id { get; set; }      
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}
