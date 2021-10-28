using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models;

namespace ToDo.Core.Abstractions.Services
{
    public interface IToDoService
    {
        Task<ToDoTask> GetAsync(int id);
        Task DeleteAsync(int id);
        Task<IEnumerable<ToDoTask>> GetAllAsync();
        Task<ToDoTask> UpdateAsync(ToDoTask toDoTask);
        Task<ToDoTask> AddAsync(ToDoTask toDoTask);
    }
}
