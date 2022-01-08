using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Entities
{
    [Serializable]
    public class City:Base
    {
        private Guid areaId;

        public Guid GetAreaId()
        {
            return areaId;
        }

        public void SetAreaId()
        {
            areaId = new Guid();
        }
    }
}
