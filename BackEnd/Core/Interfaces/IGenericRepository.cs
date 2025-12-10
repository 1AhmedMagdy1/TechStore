using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T>where T:class
    {
       public Task<IReadOnlyList<T>> GatAllAsync();
        public Task<IReadOnlyList<T>> GatAllAsync(params Expression<Func<T, object>>[]Includes);

        public Task<T?> GetByIdAsync(int i);
        public Task<T?> GetByIdAsync(int i,params Expression<Func<T, object>>[]Includes);
        public Task AddAsync(T Entity);
        public Task UpdateAsync(T Entity);
        public Task DeleteAsync(int  id);
    }
}
