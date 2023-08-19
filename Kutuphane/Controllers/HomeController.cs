using System.Diagnostics;
using Kutuphane.Data;
using Kutuphane.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.Controllers
{
    public class HomeController : Controller
    {
        //private readonly KutuphaneContext _context;
        //public HomeController(KutuphaneContext context)
        //{
        //    _context = context;
        //}

        private readonly KutuphaneContext _context;

        public HomeController(KutuphaneContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

     
       
    }
}