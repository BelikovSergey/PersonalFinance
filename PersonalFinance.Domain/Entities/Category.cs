using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Domain.ValueObjects
{
    public class Category : Entity
    {
        public DateTime Created { get; set; }

        public DateTime? Deleted { get; set; }

        public string Name { get; set; }

        public Category()
        {
        }
    }
}
