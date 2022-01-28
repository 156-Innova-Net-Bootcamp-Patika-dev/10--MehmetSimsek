using Movies.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Domain.Entities
{
    public class Genre : EntityBase
    {
        /// <summary>
        /// categories for movies like horror, adventures
        /// </summary>
        public string Name { get; set; }
    }
}
