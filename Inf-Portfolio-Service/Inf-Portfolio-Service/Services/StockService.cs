using Inf_Portfolio_Service.Models;
using Inf_Portfolio_Service.Models.Data;
using Newtonsoft.Json;
using System;

namespace Inf_Portfolio_Service.Services
{
    public class StockService
    {
        private DataService DataService { get; set; }

        public StockService()
        {
            DataService = new DataService();
        }

        public Stock GetStockById(int id)
        {
            return DataService.GetStockById(id);
        }

        public Stock GetStockByGuid(Guid guid)
        {
            return DataService.GetStockByGuid(guid);
        }

        public bool StockCrudOperations(string request, Ops ops)
        {
            Stock stock;

            try
            {
                stock = JsonConvert.DeserializeObject<Stock>(request);
            }
            catch (Exception)
            {
                return false;
            }

            switch (ops)
            {
                case Ops.Create:
                    stock.Guid = Guid.NewGuid();    
                    return DataService.CreateStock(stock);

                case Ops.Update:
                    var stockToChange = GetStockById(stock.Id);

                    stockToChange.Name = stock.Name;
                    stockToChange.Symbol = stock.Symbol;
                    stockToChange.Price = stock.Price;
                    stockToChange.Quantity = stock.Quantity;
                    stockToChange.Bought = stock.Bought;
                    stockToChange.Current = stock.Current;
                    stockToChange.Yield = stock.Yield;
                    stockToChange.PortfolioId = stock.PortfolioId;
                    return DataService.UpdateStock(stockToChange);

                case Ops.Delete:
                    var stockToDelete = GetStockByGuid(stock.Guid);
                    return DataService.DeleteStock(stockToDelete);

                default:
                    return false;
            }
        }
    }
}
