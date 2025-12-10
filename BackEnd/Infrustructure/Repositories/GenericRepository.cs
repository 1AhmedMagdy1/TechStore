using Core.Interfaces;
using Infrustructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrustructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TechStoreContext _context;

        public GenericRepository(TechStoreContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T Entity)
        {
           await _context.Set<T>().AddAsync(Entity);
           await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(int id)
        {
            var entity =await _context.Set<T>().FindAsync(id);
            if (entity == null) return;
            

             _context.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GatAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();   
        }

        public async Task<IReadOnlyList<T>> GatAllAsync(params Expression<Func<T, object>>[] Includes)
        {
            IQueryable<T> query = _context.Set<T>();
            if (Includes != null && Includes.Length > 0) {
            
            foreach(var include in Includes) { 
                query.Include(include);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int i)
        {
            var entity = await _context.Set<T>().FindAsync(i);
            return entity;
        }

        public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] Includes)
        {
            var query =  _context.Set<T>().AsQueryable();
            if (Includes != null && Includes.Length > 0)
            {
                foreach (var include in Includes)
                {
                    query = query.Include(include);
                }
            }
        return await  query.FirstOrDefaultAsync(e=>EF.Property<int>(e,"Id")==id);
        }

        public async Task UpdateAsync(T Entity)
        {
            _context.Entry(Entity).State = EntityState.Modified;
            await  _context.SaveChangesAsync();
            
        }
    }
}
