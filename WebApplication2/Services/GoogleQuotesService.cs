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
    public class GoogleQuotesService : HttpService, IQuotesService
    {
        private const string ApiUrlFormat = "http://www.google.com/finance/historical?q={0}&startdate={1}&enddate={2}&num={3}&output={4}";
        private const string OutputType = "csv";
        private const byte ResultsCount = 30;
        private const string DateFormat = "MMM d, yyyy";
        

        public async Task<IEnumerable<QuoteRecord>> GetHistoryAsync(string query, DateTime startDate, DateTime endDate)
        {
            var url = string.Format(ApiUrlFormat, query, startDate.ToString(DateFormat), endDate.ToString(DateFormat), ResultsCount, OutputType);
            var data = await GetDataAsync(url);
            
            return ParsingQuotes(data);
        }


        

    }
}