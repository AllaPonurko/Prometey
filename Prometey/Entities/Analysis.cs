using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Entities
{[Serializable]
    public class Analysis:Base
    {
        private Guid cultureId;

        public Guid GetCultureId()
        {
            return cultureId;
        }

        public void SetCultureId()
        {
            Culture culture = new Culture();
            cultureId = culture.Id;
        }
    }
}
