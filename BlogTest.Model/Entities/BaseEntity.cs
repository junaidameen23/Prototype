using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogTest.Data.Model.Entities
{
    public abstract class BaseEntity<T>
    {
        #region Constructor
        public BaseEntity()
        {
            this.IsActive = true;
        }
        #endregion

        #region Properties

        public virtual T Id { get; set; }

        [Required]
        public bool IsActive { get; set; }
        #endregion
    }
}
