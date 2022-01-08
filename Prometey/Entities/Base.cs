using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Entities
{
    public class Base
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Base ()
        {
            this.Id = new Guid();
        }
    }
}
