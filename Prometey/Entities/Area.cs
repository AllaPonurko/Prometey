using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Entities
{
    [Serializable]
    public class Area:Base
    {
        private Guid cityId;

        public Guid GetCityId()
        {
            return cityId;
        }

        public void SetCityId(City city)
        {
            cityId = city.Id;
        }
    }
}
