using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Abstractions.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(params object[] ids);
        Task<IEnumerable<T>> GetAllAsync();
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
