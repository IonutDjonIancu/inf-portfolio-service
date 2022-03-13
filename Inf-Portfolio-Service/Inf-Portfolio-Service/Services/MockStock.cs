using System;
using System.Collections.Generic;

namespace Inf_Portfolio_Service.Services
{
    public static class MockStock
    {
        public const int SECRET = 1234;

        public static List<MockPoco> GetStocks()
        {
            List<MockPoco> stocksList = new List<MockPoco>();

            var stocks = new Dictionary<string, string>
            {
                { "AALB.NL", "Aalberts" },
                { "ABN.NL", "ABN AMRO Bank" },
                { "ADYEN.NL", "Adyen" },
                { "AGN.NL", "Aegon" },
                { "AD.NL", "Ahold Delhaize" },
                { "AKZA.NL", "Akzo Nobel" },
                { "MT.NL", "ArcelorMittal" },
                { "ASML.NL", "ASML" },
                { "ASRNL.NL", "ASR Nederland" },
                { "DSM.NL", "DSM" },
                { "GLPG.NL", "Galapagos" },
                { "HEIA.NL", "Heineken" },
                { "IMCD.NL", "IMCD" },
                { "INGA.NL", "ING" },
                { "KPN.NL", "KPN" },
                { "NN.NL", "NN Group" },
                { "PHIA.NL", "Philips Koninklijke" },
                { "RAND.NL", "Randstad" },
                { "REN.NL", "RELX" },
                { "RDSA.NL", "Royal Dutch Shell A" },
                { "TKWY.NL", "Takeaway.com" },
                { "URW.NL", "Unibail-Rodamco-Westfield" },
                { "UNA.NL", "Unilever" },
                { "VPK.NL", "Vopak" },
                { "WKL.NL", "Wolters Kluwer" },
                { "AAPL.Q", "Apple" },
                { "AMZN.Q", "Amazon" },
                { "FB.Q", "Facebook" },
                { "MSFT.Q", "Microsoft" }
            };

            foreach (var item in stocks)
            {
                stocksList.Add(new MockPoco(item.Key, item.Value, RandomizePrice()));
            }

            return stocksList;
        }

        public class MockPoco
        {
            public string Symbol { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }


            public MockPoco(string symbol, string name, double price)
            {
                Symbol = symbol;
                Name = name;
                Price = price;
            }
        }

        public static double RandomizePrice()
        {
            var random = new Random();
            var max = random.Next(300);
            var index = random.NextDouble();

            return Math.Round(max * index, 2);
        }

    }

}
