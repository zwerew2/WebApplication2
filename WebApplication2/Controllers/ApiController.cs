using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Interfaces;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class ApiController : Controller
    {
        [HttpPost]
        public async Task<JsonResult> Quotes(ApiQuery q)
        {
            IQuotesService service;

            switch (q.Service)
            {
                case "Google":
                    service = new GoogleQuotesService();
                    break;
                case "Yahoo":
                    service = new YahooQuotesService();
                    break;
                default:
                    throw new Exception("Service not selected!");
            }

            var list = await service.GetHistoryAsync(q.Query, q.StartDate, q.EndDate);

            var result = new ApiResult { Quotes = list };

            return Json(result);
        }
    }
}