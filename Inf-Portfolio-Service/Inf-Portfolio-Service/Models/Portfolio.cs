using System;
using System.Collections.Generic;

namespace Inf_Portfolio_Service.Models
{
    public partial class Portfolio
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public string Name { get; set; }
        public int Code { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
