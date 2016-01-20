using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Interfaces;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class YahooQuotesService : HttpService, IQuotesService
    {
        private const string ApiUrlFormat = "http://real-chart.finance.yahoo.com/table.csv?s={0}&a={1}&b={2}&c={3}&d={4}&e={5}&f={6}&g={7}&ignore={8}";
        private const string OutputType = ".csv";
        private const string PeriodicType = "d";
        

        public async Task<IEnumerable<QuoteRecord>> GetHistoryAsync(string query, DateTime startDate, DateTime endDate)
        {
            var url = string.Format(ApiUrlFormat, query, startDate.Month - 1, startDate.Day, startDate.Year, endDate.Month - 1, endDate.Day, endDate.Year, PeriodicType, OutputType);
            var data = await GetDataAsync(url);

            return ParsingQuotes(data);
        }
    }
}