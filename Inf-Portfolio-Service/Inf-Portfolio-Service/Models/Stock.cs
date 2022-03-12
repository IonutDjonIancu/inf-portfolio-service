using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inf_Portfolio_Service.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Bought { get; set; }
        public double Current { get; set; }
        public double Yield { get; set; }

        public Guid PortfolioId { get; set; } // although it's called Id i'm using the Guid from Portfolio to uniquely indentify the relationship
        public Portfolio Portfolio { get; set; }


    }
}
