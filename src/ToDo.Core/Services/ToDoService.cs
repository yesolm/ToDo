using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Abstractions;
using ToDo.Core.Abstractions.Services;
using ToDo.Core.Models;

namespace ToDo.Core.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ToDoService(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ToDoTask> AddAsync(ToDoTask toDoTask)
        {
            _unitOfWork.ToDos.Add(toDoTask);
            await _unitOfWork.CompleteAsync();
            return toDoTask;
        }

        public async Task DeleteAsync(int id)
        {
            var toDoTask = await _unitOfWork.ToDos.GetAsync(id);
            _unitOfWork.ToDos.Remove(toDoTask);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ToDoTask>> GetAllAsync()
        {
            return await _unitOfWork.ToDos.GetAllAsync();
        }

        public async Task<ToDoTask> GetAsync(int id)
        {
            return await _unitOfWork.ToDos.GetAsync(id);
        }

        public async Task<ToDoTask> UpdateAsync(ToDoTask toDoTask)
        {
            _unitOfWork.ToDos.Update(toDoTask);
            await _unitOfWork.CompleteAsync();
            return toDoTask;
        }
    }

}
