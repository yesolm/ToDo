using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Abstractions.Repositories;

namespace ToDo.Core.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IToDoRepository ToDos { get; }
        Task<int> CompleteAsync();
    }
}
