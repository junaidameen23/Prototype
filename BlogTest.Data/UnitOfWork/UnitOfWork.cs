using BlogTest.Data.DbContext;
using BlogTest.Data.Model.Entities;
using BlogTest.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogTest.Model.Entities;

namespace BlogTest.Data.UnitOfWork
{
    public class UnitOfWork : Disposable, IUnitOfWork
    {
        /// <summary>
        /// DbContext object.
        /// </summary>
        readonly BlogTestDbContext _dataContext;

        /// <summary>
        /// Constructor.
        /// </summary>
        public UnitOfWork()
        {
            _dataContext = new BlogTestDbContext();
        }

        /// <summary>
        /// Commits the unit of work.
        /// </summary>
        /// <returns></returns>
        public async virtual Task<int> CommitAsync()
        {
            try
            {
                return await _dataContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Repositories implementations.
        /// </summary>

        private IRepository<Gender> _gender;
        public IRepository<Gender> Gender
        {
            get
            {
                return _gender ?? (_gender = new Repository<Gender>(_dataContext));
            }
        }

        private IRepository<Employee> _employee;
        public IRepository<Employee> Employee
        {
            get
            {
                return _employee ?? (_employee = new Repository<Employee>(_dataContext));
            }
        }
    }
}
