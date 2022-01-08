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
    public class DataCollectoinCity:IDataCollection<City>
    {
        public List<City> cities;
        public string FileName { get; set; }
        public void Load()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<City>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".cities.xml", FileMode.Open))
                {
                    cities = (List<City>)formatterUser.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        public void Save()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<City>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".cities.xml", FileMode.OpenOrCreate))
                {
                    formatterUser.Serialize(fs, cities);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        public void AddListCity(City city)
        {
            if (cities == null) cities = new List<City>();
            foreach (City item in cities)
            {
                if (city != item)
                    cities.Add(city);
                else
                {
                    WriteLine("Такой город уже существует!");
                }
            }

        }
    }
}
