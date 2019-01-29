using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Data.Repository
{
    public interface IRepository<T> where T : class
    {

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T, bool>> where);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
    }
}
