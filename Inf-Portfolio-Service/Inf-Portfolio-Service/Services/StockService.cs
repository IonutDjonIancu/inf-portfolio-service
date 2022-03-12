using Inf_Portfolio_Service.Models;
using Inf_Portfolio_Service.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    return DataService.DeleteStock(stock);

                default:
                    return false;
            }
        }

        //public bool CreateStock(string request)
        //{
        //    Stock stock;

        //    try
        //    {
        //        stock = JsonConvert.DeserializeObject<Stock>(request);
        //        stock.Guid = Guid.NewGuid();
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return DataService.CreateStock(stock);
        //}

        //public bool UpdateStock(string request)
        //{
        //    Stock stock;
        //    Stock stockToChange;

        //    try
        //    {
        //        stock = JsonConvert.DeserializeObject<Stock>(request);

        //        stockToChange = GetStockById(stock.Id);

        //        stockToChange.Name = stock.Name;
        //        stockToChange.Symbol = stock.Symbol;
        //        stockToChange.Price = stock.Price;
        //        stockToChange.Quantity = stock.Quantity;
        //        stockToChange.Bought = stock.Bought;
        //        stockToChange.Current = stock.Current;
        //        stockToChange.Yield = stock.Yield;
        //        stockToChange.PortfolioId = stock.PortfolioId;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return DataService.CreateStock(stock);
        //}

        //public bool DeleteStock(string request)
        //{
        //    Stock stock;

        //    try
        //    {
        //        stock = JsonConvert.DeserializeObject<Stock>(request);
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }

        //    return DataService.DeleteStock(stock);
        //}

    }
}
