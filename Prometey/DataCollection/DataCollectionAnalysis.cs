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
    public class DataCollectionAnalysis : IDataCollection<Analysis>
    {
        public List<Analysis> analyses;
        public string FileName { get; set; }
        public void Load()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Analysis>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".analysis.xml", FileMode.Open))
                {
                    analyses = (List<Analysis>)formatterUser.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        public void Save()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Analysis>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".analysis.xml", FileMode.OpenOrCreate))
                {
                    formatterUser.Serialize(fs, analyses);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        public void AddListAnalysis(Analysis analyse)
        {
            if (analyses == null) analyses = new List<Analysis>();
            foreach (Analysis item in analyses)
            {
                if (analyse != item)
                    analyses.Add(analyse);
                else
                {
                    WriteLine("Такой анализ уже существует!");

                }
            }

        }
    }
}
