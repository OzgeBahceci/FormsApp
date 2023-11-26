using FormsApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormsApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {

            //buraya tüm Ürünler gönderiliyor 
            return View(Repository.Products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}