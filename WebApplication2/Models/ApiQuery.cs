using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    //класс для результата запроса
    public class ApiQuery
    {
        public string Query { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Service { get; set; }
    }
}