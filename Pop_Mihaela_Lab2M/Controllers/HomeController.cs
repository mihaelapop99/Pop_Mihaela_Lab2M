using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pop_Mihaela_Lab2M.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pop_Mihaela_Lab2M.Data;
using Pop_Mihaela_Lab2M.Models.LibraryViewModels;

namespace Pop_Mihaela_Lab2M.Controllers
{
    public class HomeController : Controller
    {



        //lab4
        private readonly LibraryContext _context;
        public HomeController(LibraryContext context)
        {
            _context = context;
        }
        //
        public async Task<ActionResult> Statistics()
        {
            IQueryable<OrderGroup> data =
            from order in _context.Orders
            group order by order.OrderDate into dateGroup
            select new OrderGroup()
            {
                OrderDate = dateGroup.Key,
                BookCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }
        //pana aici






        /*
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        */


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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
