using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Models;
using WebApplication2.Interfaces;

namespace WebApplication2.Services
{
    public class RandomQuotesService : IQuotesService
    {
        public async Task<IEnumerable<QuoteRecord>> GetHistoryAsync(string query, DateTime startDate, DateTime endDate)
        {
            return await Task.Factory.StartNew(() => GenerateQuotes(query, startDate, endDate));
        }

        private IEnumerable<QuoteRecord> GenerateQuotes(string query, DateTime startDate, DateTime endDate)
        {
            var list = new List<QuoteRecord>();
            Random rand = new Random();


            for (DateTime i = startDate; i < endDate; i = i.AddMonths(1))
            {
               // list.Add(new QuoteRecord { Date = i, Open = rand.Next(2000, 3000) / 100, High = rand.Next(3000, 5000)/100, Low = rand.Next(1000, 2000)/100, Close = rand.Next(2000, 3000)/100, Volume = rand.Next(10000000, 100000000) });
            }
            


            return list;
        }

    }
}