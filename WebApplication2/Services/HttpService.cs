using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public abstract class HttpService
    {
        protected virtual async Task<string> GetDataAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(url);
            }
        }

        protected virtual IEnumerable<QuoteRecord> ParsingQuotes(string data)
        {
            List<QuoteRecord> list = new List<QuoteRecord>();

            string[] rows = data.Split('\n');

            for (int i = 1; i < rows.Length - 1; i++)
            {
                string[] g = rows[i].Split(',');
                list.Add(new QuoteRecord
                {
                    Date = g[0],
                    Open = g[1],
                    High = g[2],
                    Low = g[3],
                    Close = g[4],
                    Volume = g[5]
                });
            }

            return list;
        }

    }
}