using System;
using System.Collections.Generic;

namespace Inf_Portfolio_Service.Models.ViewModels
{
    public class PortfolioVm
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }

        public string Name { get; set; }
        public int Code { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
