using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inf_Portfolio_Service.Models.Data
{
    public class DataService
    {
        private PortfolioDbContext Context { get; set; }

        public DataService()
        {
            Context = new PortfolioDbContext();
        }

        #region Portfolio CRUD
        public List<Portfolio> GetPortfolios()
        {
            return Context.Portfolios.ToList();
        }

        public Portfolio GetPortfolioById(int id)
        {
            return Context.Portfolios.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }


        public bool CreatePortfolio(Portfolio portfolio)
        {
            try
            {
                Context.Portfolios.Add(portfolio);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdatePortfolio(Portfolio portfolio)
        {
            try
            {
                Context.Portfolios.Update(portfolio);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        #endregion


        #region Stock CRUD

        public Stock GetStockById(int id)
        {
            return Context.Stocks.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }

        public bool CreateStock(Stock stock)
        {
            try
            {
                Context.Stocks.Add(stock);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool UpdateStock(Stock stock)
        {
            try
            {
                Context.Stocks.Update(stock);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool DeleteStock(Stock stock)
        {
            try
            {
                Context.Stocks.Remove(stock);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
