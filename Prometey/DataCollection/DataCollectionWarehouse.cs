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
   public class DataCollectionWarehouse : IDataCollection<Warehouse>
    {
        public List<Warehouse> warehouses;

        public string FileName { get; set; }
        public List<Warehouse> Load()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Warehouse>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".warehouses.xml", FileMode.Open))
                {
                    warehouses = (List<Warehouse>)formatterUser.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
            return warehouses;
        }

        public void Save()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Warehouse>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".warehouses.xml", FileMode.OpenOrCreate))
                {
                    formatterUser.Serialize(fs, warehouses);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        public void AddListWarehouse(Warehouse warehouse)
        {
            if (warehouses == null) warehouses = new List<Warehouse>();
            foreach (Warehouse item in warehouses)
            {
                if (warehouse != item)
                    warehouses.Add(warehouse);
                else
                {
                    WriteLine("Такой склад уже существует!");

                }
            }

        }
    }
}
