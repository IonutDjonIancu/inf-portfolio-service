using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inf_Portfolio_Service.Models;
using Inf_Portfolio_Service.Services;
using Microsoft.AspNetCore.Mvc;


namespace Inf_Portfolio_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        // GET: /api/portfolio/GetOk
        [HttpGet("GetOk")]
        public string GetOk()
        {
            return "all okay";
        }

        // GET: /api/portfolio/GetPortfolios
        [HttpGet("GetPortfolios")]
        public List<Portfolio> GetPortfolios() // quite the antipattern here to return the model directly from the db, a viewmodel could have been used instead
        {
            var portService = new PortfolioService();

            return portService.GetAllPortfolios();
        }


        // GET: /api/portfolio/GetPortfolioById/5
        [HttpGet("GetPortfolioById/{id}")]
        public Portfolio GetPortfolioById(int id)
        {
            var portService = new PortfolioService();

            return portService.GetPortfolioById(id);
        }

        // POST: /api/portfolio/CreatePortfolio
        [HttpPost("CreatePortfolio")]
        public bool CreatePortfolio([FromBody] string request)
        {
            var portService = new PortfolioService();

            return portService.CreatePortfolio(request);
        }

        // PUT: /api/portfolio/UpdatePortfolio
        [HttpPut("UpdatePortfolio")]
        public bool UpdatePortfolio([FromBody] string request)
        {
            var portService = new PortfolioService();

            return portService.UpdatePortfolio(request);
        }
    }
}
