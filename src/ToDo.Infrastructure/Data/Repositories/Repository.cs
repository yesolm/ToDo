using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Core.Abstractions.Repositories;

namespace ToDo.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T>
          where T : class
    {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(T entity) => Context.Set<T>().Add(entity);
        public async Task<T> GetAsync(params object[] ids) => await Context.Set<T>().FindAsync(ids);
        public async Task<IEnumerable<T>> GetAllAsync() => await Context.Set<T>().ToListAsync();
        public void Remove(T entity) => Context.Set<T>().Remove(entity);
        public void Update(T entity) => Context.Set<T>().Update(entity);
    }
}
