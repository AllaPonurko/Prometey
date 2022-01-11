using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Entities
{[Serializable]
    public class Analysis:Base
    {
        public Analysis(Culture culture)
        {
            Name = "Анализ культуры "+$"{culture.Name}" +" на соответствие норме";
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
        public bool Result = false;
        
        
    }
}
