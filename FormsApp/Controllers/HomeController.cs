using FormsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace FormsApp.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        //buradaki string searchString url'de q=iphone olarak kullanılacak
        //string category ile category bilgisi alındı
        public IActionResult Index(string searchString, string category)
        {
            //Tüm productslar alındı
            var products = Repository.Products;

            //Eğer searchString boş değilse yani urle bir değer girilmişse bir filtreleme yap
            if (!String.IsNullOrEmpty(searchString))
            {

                //arama yapılan string ifade, arama yapıldıktan sora da kalsın diye yakalandı
                ViewBag.SearchString = searchString;

                //eğer searchString gelen ürünler arasında varsa bu ürünleri liste olarak dön
                //küçük büyük harf duyarlı old. için Name önce küçük harfe çevrildi
                products = products.Where(p => p.Name.ToLower().Contains(searchString)).ToList();
            }

            //Kategory için filtreleme eğer 0(hepsi) seçilmedikçe
            if (!String.IsNullOrEmpty(category) && category!="0")
            {
                // gelen id'ye eşitse o kategoriye ait ürünleri döndür
                products = products.Where(p => p.CategoryId== int.Parse(category)).ToList();
            }

            //Görünen Name ama CategoryId'ye göre işlem yapılacak
            ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name");


            //buraya alınan ürünler gönderiliyor 
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}