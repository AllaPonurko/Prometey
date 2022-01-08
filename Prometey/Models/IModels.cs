using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Models
{
    public interface IModels
    {
        public string FileName { get; set; }
        public void Load();
        public void Save();
    }
}
