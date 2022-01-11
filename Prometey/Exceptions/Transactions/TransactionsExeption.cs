using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometey.Exceptions.Transactions
{
    public class TransactionsExeption:Exception
    {
        public string Message_ { get; set; }
    }
}
