using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Entities
{
    [Serializable]
    public class Warehouse:Base
    {
        public Culture Culture = new Culture();
        public Warehouse() { }
        public Warehouse(string Name,double Capacity)
        {
            this.Name = Name;
            this.Capacity = Capacity;
        }
        public double Capacity { get; set; }

        private Guid cityId;

        public Guid GetCityId()
        {
            return cityId;
        }

        public void SetCityId(City city)
        {
            cityId = city.Id;
        }

        private Guid cultureId;

        public Guid GetCultureId()
        {
            return cultureId;
        }

        public void SetCultureId(Culture culture)
        {
            cultureId = culture.Id;
        }
    }
}
