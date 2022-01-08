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
    public class DataCollectionTransaction:IDataCollection<Transaction>
    {
        public List<Transaction> transactions;
        public string FileName { get; set; }
        public void Load()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Transaction>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".transactions.xml", FileMode.Open))
                {
                    transactions = (List<Transaction>)formatterUser.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        public void Save()
        {
            XmlSerializer formatterUser = new XmlSerializer(typeof(List<Transaction>));
            try
            {
                using (FileStream fs = new FileStream(FileName + ".transactions.xml", FileMode.OpenOrCreate))
                {
                    formatterUser.Serialize(fs, transactions);
                }

            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }
        public void AddListTransaction(Transaction transaction)
        {
            if (transactions == null) transactions = new List<Transaction>();
            
                    transactions.Add(transaction);
           
        }
    }
}
