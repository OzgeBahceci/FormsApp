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

        //buradaki string searchString url'de q=iphone olarak kullanılacak
        public IActionResult Index(string searchString)
        {
            //Tüm productslar alındı
            var products = Repository.Products;

            //Eğer searchString boş değilse yani urle bir değer girilmişse bir filtreleme yap
            if (!String.IsNullOrEmpty(searchString))
            {
                //eğer searchString gelen ürünler arasında varsa bu ürünleri liste olarak dön
                //küçük büyük harf duyarlı old. için Name önce küçük harfe çevrildi
                products = products.Where(p => p.Name.ToLower().Contains(searchString)).ToList();
            }

            //buraya alınan ürünler gönderiliyor 
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}