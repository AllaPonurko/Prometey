using Prometey.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Console;
namespace Prometey.DataCollection
{
    public class DataCollectionArea:IDataCollection<Area>
    {
        public List<Area>areas { get; set; }
        public string FileName { get; set; }
        public void Load()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Area>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".areas.xml", FileMode.Open))
                {
                    areas = (List<Area>)formatterUser.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        public void Save()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Area>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".areas.xml", FileMode.OpenOrCreate))
                {
                    formatterUser.Serialize(fs, areas);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        public void AddListArea(Area area)
        {
            if (areas == null) areas = new List<Area>();
            foreach (Area item in areas)
            {
                if (area != item)
                    areas.Add(area);
                else
                {
                    WriteLine("Такая область уже существует!");

                }
            }

        }
    }
}
