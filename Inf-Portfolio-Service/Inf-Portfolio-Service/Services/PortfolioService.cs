using Inf_Portfolio_Service.Models;
using Inf_Portfolio_Service.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inf_Portfolio_Service.Services
{
    public class PortfolioService
    {
        private DataService dataService { get; set; }

        public PortfolioService()
        {
            dataService = new DataService();
        }

        public List<Portfolio> GetAllPortfolios()
        {
            return dataService.GetPortfolios();
        }

        public Portfolio GetPortfolioById(int id)
        {
            return dataService.GetPortfolioById(id);
        }

        public bool CreatePortfolio(string request)
        {
            Portfolio portfolio;

            try
            {
                portfolio = JsonConvert.DeserializeObject<Portfolio>(request);
                portfolio.Guid = Guid.NewGuid();
            }
            catch (Exception)
            {
                return false;
            }

            return dataService.CreatePortfolio(portfolio);
        }

        public bool UpdatePortfolio(string request)
        {
            Portfolio portfolio;
            Portfolio portfolioToChange;

            try
            {
                portfolio = JsonConvert.DeserializeObject<Portfolio>(request);

                portfolioToChange = GetPortfolioById(portfolio.Id);

                portfolioToChange.Name = portfolio.Name;
                portfolioToChange.Code = portfolio.Code;
            }
            catch (Exception)
            {
                return false;
            }

            return dataService.UpdatePortfolio(portfolioToChange);
        }

    }
}
