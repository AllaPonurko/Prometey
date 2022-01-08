using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.DataCollection
{
    public interface IDataCollection<Entity>
    {
        
        public void Save();
        //public void Load();
    }
}
