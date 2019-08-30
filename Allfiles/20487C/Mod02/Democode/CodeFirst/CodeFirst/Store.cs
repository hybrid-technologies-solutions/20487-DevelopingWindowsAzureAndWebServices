using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class Store
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
