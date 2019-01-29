using BlogTest.Data.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Model.Entities
{
    public class Employee : BaseEntity<int>
    {
        #region Constructor
        public Employee()
        {

        }
        #endregion

        #region Properties
        public string EmployeeName { get; set; }

        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Salary { get; set; }
        #endregion

    }
}
