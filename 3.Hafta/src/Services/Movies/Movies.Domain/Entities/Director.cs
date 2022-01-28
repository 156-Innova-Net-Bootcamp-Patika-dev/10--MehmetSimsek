using Movies.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Director: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
