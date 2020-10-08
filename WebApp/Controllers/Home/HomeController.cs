using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Models;

namespace WebApp.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly GestorContext _gestorContext;
        public HomeController(ILoggerFactory loggerFactory,GestorContext gestorContext)
        {
            _logger = loggerFactory.CreateLogger(nameof(HomeController));
            _gestorContext = gestorContext;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public JsonResult getTipos()
        {
            _logger.LogInformation("ha entrado en mi log");
            var primerProgramador = _gestorContext.TipoProgramadores.ToList();
            return Json(primerProgramador);
        }
        public JsonResult getProgramadores()
        {
            return Json(_gestorContext.Programadores.ToList());
        }
    }
}
