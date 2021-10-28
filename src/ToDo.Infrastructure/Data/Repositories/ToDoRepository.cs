
using ToDo.Core.Abstractions.Repositories;
using ToDo.Core.Models;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class ToDoRepository : Repository<ToDoTask>, IToDoRepository
    {
        public ToDoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}