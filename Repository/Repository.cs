using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationContext _context;
        private DbSet<T> _entities;

        public Repository(ApplicationContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<List<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<int> Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.CreatedDate = DateTime.UtcNow;

            _entities.Add(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            entity.ModifiedDate = DateTime.UtcNow;
            _context.Entry(entity).State = EntityState.Modified;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _entities.Remove(entity);
            return await _context.SaveChangesAsync();
        }
    }
}
