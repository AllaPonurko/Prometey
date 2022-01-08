using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Entities
{
    [Serializable]
    public class Manager:Base
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Manager ()
        {
            Name = "Менеджер";
        }
    }
}
