using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversityApp.Services.Repository.Interfaces;

namespace UniversityApp.Services.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> entity;

        public Repository(DbContext context)
        {
            this.context = context;
            entity = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(object id) => await entity.FindAsync(id);

        protected DbSet<T> GetEntity() => entity;

        public async Task InsertAsync(T obj)
        {
            await entity.AddAsync(obj);
            await SaveAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            entity.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            await SaveAsync();
        }

        public async Task DeleteAsync(object id)
        {
            T existing = await entity.FindAsync(id);
            entity.Remove(existing);
            await SaveAsync();
        }

        public async Task SaveAsync() => await context.SaveChangesAsync();

    }
}
