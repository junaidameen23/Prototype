using BlogTest.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Model.Entities
{
    public class Gender : BaseEntity<int>
    {
        #region Constructor
        public Gender()
        {
        }
        #endregion

        #region Properties
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        #endregion
    }
}
