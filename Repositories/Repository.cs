using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApp.Models;

namespace MovieApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly MovieContext context;
        private DbSet<T> entities;

        public Repository(MovieContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }
        public Task<List<T>> GetAllAsync()
        {
            return entities.ToListAsync<T>();
        }

        public Task<T> GetAsync(int id, bool isActive = true)
        {
            return entities.FirstOrDefaultAsync(s => s.Id == id && (s.Active || !isActive));
        }


        public async Task InsertAsync(T entity, bool saveChange = true)
        {
            entity.CreatedTime = DateTime.Now;
            entity.UpdatedTime = DateTime.Now;
            entity.Active = true;

            var movieCreated = await entities.AddAsync(entity);

            if (saveChange)
                await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity, bool saveChange = true)
        {
            entity.UpdatedTime = DateTime.Now;
            if (saveChange)
                await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity, bool saveChange = true)
        {
            entities.Remove(entity);
            if (saveChange)
                await context.SaveChangesAsync();
        }
    }
}