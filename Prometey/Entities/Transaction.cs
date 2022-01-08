using Prometey.DataCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Prometey.Entities
{
    [Serializable]
    public class Transaction:Base
    {

        public Transaction()
        {
            Name = "Новая сделка\t"+$"{DateTime.Now}";
        }
        /// <summary>
        /// Id менеджера
        /// </summary>
        private Guid managerId;

        public Guid GetManagerId()
        {
            return managerId;
        }

        public void SetManagerId(Manager manager)
        {
               managerId = manager.Id;
        }
        /// <summary>
        /// Id культуры
        /// </summary>
        private Guid cultureId;

        public Guid GetCultureId()
        {
            return cultureId;
        }

        public void SetCultureId(Culture culture)
        {
             cultureId = culture.Id;
        }
        /// <summary>
        /// цена продажи
        /// </summary>
        private double transactionPrice;

        public double GetTransactionPrice()
        {
            return transactionPrice;
        }

        public void SetTransactionPrice(Culture culture)
        {
            transactionPrice = culture.Price;
        }
        /// <summary>
        /// проданное количество
        /// </summary>
        public double TransactionCount { get; set; }

        private Guid warehouseId;

        /// <summary>
        ///Id склада, учавствующего в транзакции
        /// </summary>
        public Guid GetWarehouseId()
        {
            return warehouseId;
        }

        /// <summary>
        ///Id склада, учавствующего в транзакции
        /// </summary>
        public void SetWarehouseId()
        {
            Warehouse warehouse = new Warehouse();
            warehouseId = warehouse.Id;
        }

        public void TransactionSale(Culture culture,Warehouse warehouse)
        {
            TransactionCount = Convert.ToDouble(ReadLine());
            if (culture.Count>= TransactionCount && culture.Id==warehouse.GetCultureId())
                try
                {
                    double Sum = TransactionCount * culture.Price;
                    culture.Count -= TransactionCount;
                    WriteLine($"{culture.Name}\t" + $"{culture.Price}\t" + $"{TransactionCount}\t" + $"{Sum}");
                }
                catch(Exception e)
                {
                    WriteLine(e.Message);
                }
            else
            {
                WriteLine($"По выбранному складу недостаточное для сделки количество:\n Требуется "
                    +$"{TransactionCount}\t"+$"В наличии "+$"{culture.Count}") ;
                DataCollectionWarehouse warehouse1 = new DataCollectionWarehouse();
                List<Warehouse> warehouses = warehouse1.Load();
                foreach(Warehouse item in warehouses)
                {
                    if (culture.Id == item.GetCultureId())
                        WriteLine($"{item.Name}\t" + $"{item.Culture.Name}\t" + $"{item.Culture.Count}");
                }

            }
        }
        public void TransactionBuy()
        {

        }
    }
}
