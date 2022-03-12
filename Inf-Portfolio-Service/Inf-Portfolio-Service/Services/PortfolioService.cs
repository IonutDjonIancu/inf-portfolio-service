﻿using Inf_Portfolio_Service.Models;
using Inf_Portfolio_Service.Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inf_Portfolio_Service.Services
{
    public class PortfolioService // verbose CRUD methods
    {
        private DataService DataService { get; set; }

        public PortfolioService()
        {
            DataService = new DataService();
        }

        public List<Portfolio> GetAllPortfolios()
        {
            return DataService.GetPortfolios();
        }

        public Portfolio GetPortfolioById(int id)
        {
            return DataService.GetPortfolioById(id);
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

            return DataService.CreatePortfolio(portfolio);
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

            return DataService.UpdatePortfolio(portfolioToChange);
        }

    }
}