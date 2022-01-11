using Prometey.DataCollection;
using Prometey.Exceptions.Transactions;
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
        public void SetWarehouseId(Warehouse warehouse)
        {
            warehouseId = warehouse.Id;
        }
        /// <summary>
        /// метод проверки выполнения анализа
        /// </summary>
        /// <param name="analysis">анализ</param>
        /// <returns></returns>
        public bool Implement(Analysis analysis)
        {
            if (analysis != null)
                analysis.Result = true;
            else analysis.Result = false;
            return analysis.Result;
        }
        /// <summary>
        /// транзакция по продаже
        /// </summary>
        /// <param name="culture">культура</param>
        public void TransactionSale(Culture culture)
        {
            TransactionCount = Convert.ToDouble(ReadLine());
            DataCollectionWarehouse warehouse1 = new DataCollectionWarehouse();
            _ = new List<Warehouse>();
            List<Warehouse> warehouses = warehouse1.Load();
            List<Warehouse> warehousesTemp = new List<Warehouse>();
            Analysis analysis = new Analysis(culture);
            if (warehouses != null)
                foreach (Warehouse item in warehouses)
                {
                    if (culture.Id == item.Culture.Id && item.Culture.Count >= TransactionCount)
                    { 
                        WriteLine($"{item.Name}\t" + $"{item.Culture.Name}\t" + $"{item.Culture.Count}");
                        warehousesTemp.Add(item);
                    }
                    else
                    { 
                    }
                }
            else
            {
                throw new TransactionsExeption();
            }
            WriteLine($"Выберите склад:\n");
            string Temp=ReadLine();
            foreach (Warehouse item in warehousesTemp)
                if (item.Name == Temp)
                {
                    try
                    {
                        double Sum = TransactionCount * item.Culture.Price;
                        item.Culture.Count -= TransactionCount;
                        WriteLine($"{item.Culture.Name}\t" + $"{item.Culture.Price}\t" + $"{TransactionCount}\t" + $"={Sum}");
                        if (Implement(analysis) == true)
                            WriteLine($"Анализ подтверждён");
                    }
                    catch (TransactionsExeption e)
                    {
                        WriteLine(e.Message);
                    }
                }
                
        }
        /// <summary>
        /// транзакция по покупке
        /// </summary>
        /// <param name="culture">культура</param>
        public void TransactionBuy(Culture culture)
        {
            TransactionCount = Convert.ToDouble(ReadLine());
            DataCollectionWarehouse warehouse1 = new DataCollectionWarehouse();
            _ = new List<Warehouse>();
            List<Warehouse> warehouses = warehouse1.Load();
            List<Warehouse> warehousesTemp = new List<Warehouse>();
            Analysis analysis = new Analysis(culture);
            if (warehouses != null)
                foreach (Warehouse item in warehouses)
                {
                    if (item.Capacity >= TransactionCount)
                    {
                        warehousesTemp.Add(item);
                    }
                    else
                    {
                    }
                }
            else
            {
                throw new TransactionsExeption();
            }
            WriteLine($"Выберите склад:\n");
            string Temp = ReadLine();
            foreach (Warehouse item in warehousesTemp)
                if (item.Name == Temp)
                {
                    try
                    {
                        double Sum = TransactionCount * item.Culture.Price;
                        item.Culture.Count += TransactionCount;
                        WriteLine($"{item.Culture.Name}\t" + $"{item.Culture.Price}\t" + $"{TransactionCount}\t" + $"={Sum}");
                        if (Implement(analysis) == true)
                            WriteLine($"Анализ подтверждён");
                    }
                    catch (TransactionsExeption e)
                    {
                        WriteLine(e.Message);
                    }
                }


        }
    }
}
