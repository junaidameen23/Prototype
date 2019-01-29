using BlogTest.Data.Model.Entities;
using BlogTest.Data.Repository;
using BlogTest.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits the unit of work.
        /// </summary>
        Task<int> CommitAsync();

        /// <summary>
        /// Repository intefaces
        /// </summary>

        IRepository<Gender> Gender { get; }
        IRepository<Employee> Employee { get; }
    }
}
