using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Controllers
{
    public class AplicacionesController : Controller
    {
        private readonly ILogger<AplicacionesController> _logger;

        public AplicacionesController(ILogger<AplicacionesController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult Calculadora()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
