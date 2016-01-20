using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Interfaces
{
    public interface IQuotesService
    {
        Task<IEnumerable<QuoteRecord>> GetHistoryAsync(string query, DateTime startDate, DateTime endDate);
    }
}
