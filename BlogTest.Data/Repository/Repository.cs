using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Data.Repository
{
    public class Repository<T> : Disposable, IRepository<T> where T : class
    {
        private readonly System.Data.Entity.DbContext _dataContext;

        private IDbSet<T> Dbset
        {
            get { return _dataContext.Set<T>(); }
        }

        public Repository(System.Data.Entity.DbContext dbContext)
        {
            _dataContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Dbset.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> @where)
        {
            return await Dbset.FirstOrDefaultAsync(where);
        }

        public async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> @where)
        {
            return await Dbset.Where(where).ToListAsync();
        }


        public void Insert(T entity)
        {
            Dbset.Add(entity);
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Dbset.Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Delete(int id)
        {
            try
            {
                var entity = Dbset.Find(id);
                if (entity == null)
                    throw new ObjectNotFoundException("entity");
                Dbset.Remove(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void Delete(T entity)
        {
            Dbset.Remove(entity);
        }

        public void Delete(Expression<Func<T, bool>> @where)
        {
            var objects = Dbset.Where(where).AsEnumerable();
            foreach (var obj in objects)
                Dbset.Remove(obj);
        }

    }
}
