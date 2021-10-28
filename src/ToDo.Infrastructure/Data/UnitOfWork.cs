using System;
using System.Threading.Tasks;
using ToDo.Core.Abstractions;
using ToDo.Core.Abstractions.Repositories;
using ToDo.Infrastructure.Data.Repositories;

namespace ToDo.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IToDoRepository _toDos;
        public IToDoRepository ToDos => _toDos ?? (_toDos = new ToDoRepository(_context));
        public UnitOfWork(ApplicationDbContext context) => _context = context;
        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }
}