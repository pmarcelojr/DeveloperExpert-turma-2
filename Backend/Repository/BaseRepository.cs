using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class BaseRepository<T> where T : class
    {
        public DbContext Context { get; set; }
        public DbSet<T> Query { get; set; }

        public BaseRepository(AppDbContext context)
        {
            Context = context;
            Query = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Query.ToListAsync(); 
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Query.FindAsync(id); 
        }
        
        public async Task RemoveAsync(T obj)
        {
            Query.Remove(obj);
            await Context.SaveChangesAsync(); 
        }

        public async Task SaveAsync(T obj)
        {
            await Query.AddAsync(obj);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T obj)
        {
            Query.Update(obj); 
            await Context.SaveChangesAsync();
        }
    }
}