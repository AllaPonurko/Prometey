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
    public class DataCollectionCulture : IDataCollection<Culture>

    {
        public List<Culture> cultures { get; set; }
        public string FileName { get; set; }
        public void Load()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Culture>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".cultures.xml", FileMode.Open))
                {
                    cultures = (List<Culture>)formatterUser.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        public void Save()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Culture>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".cultures.xml", FileMode.OpenOrCreate))
                {
                    formatterUser.Serialize(fs, cultures);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        public void AddListCulture(Culture culture)
        {
            if (cultures == null) cultures = new List<Culture>();
            foreach (Culture item in cultures)
            {
                if (culture != item)
                    cultures.Add(culture);
                else
                {
                    WriteLine("Такая культура уже существует!");

                }
            }

        }
    }
}
