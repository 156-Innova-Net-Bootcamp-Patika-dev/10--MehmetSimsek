using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.Entities.Commons
{
    public abstract class EntityBase
    {

        public int Id { get; set; }
     
        public DateTime CreatedDate { get; set; }


        public DateTime LastModifiedDate { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
