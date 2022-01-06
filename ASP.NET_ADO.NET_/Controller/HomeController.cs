using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ADONETCORE.DataLayer;
using ASP.NET_ADO.NET_;

namespace ADONETCORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CustomerDAL _CustomerDAL = new CustomerDAL();
            List<Customers> CustomerList = new List<Customers>();
            CustomerList = _CustomerDAL.GetAllCustomers();
            return View(CustomerList);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
