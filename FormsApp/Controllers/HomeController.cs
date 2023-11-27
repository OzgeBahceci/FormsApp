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
            if (!String.IsNullOrEmpty(category) && category != "0")
            {
                // gelen id'ye eşitse o kategoriye ait ürünleri döndür
                products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
            }

            //Görünen Name ama CategoryId'ye göre işlem yapılacak
            //4. parametre olan category arama yapıldıktan sonra ekranda göstermek için
            // ViewBag.Categories = new SelectList(Repository.Categories,"CategoryId","Name", category);


            var model = new ProductViewModel
            {
                Products = products,
                Categories = Repository.Categories,
                SelectedCategory = category
            };


            //buraya alınan ürünler gönderiliyor 
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        //IFormFile formFile resmi almak için
        public async Task<IActionResult> Create(Product model, IFormFile imageFile)
        {
            var extension = Path.GetExtension(imageFile.FileName); //abc.jpg -> jpg kısmını alır
            //random isim oluştu ve extension kısmı eklendi, random vermezsen ismi kontrol etmen lazım
            var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName); // resmin kaydedileceği adres

            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                }
                model.Image = randomFileName; // ismini modele ver

                //içerideki sayının bir fazlasını id olarak ver 
                model.ProductId = Repository.Products.Count + 1;
                Repository.CreateProduct(model);
                return RedirectToAction("Index");
            }

            //Kategori içeriği dolu gelsin
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");


            //eğer hata varsa view'a gönder ama model ile birilikte girilimiş dataları da yazdır
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();// 404 sayfasına yönlendirme
            }

            //id null değilse
            var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);// yukarıda gönderdiğimiz id eşleşiyorsa
            if (entity == null)
            {
                return NotFound();// 404 sayfasına yönlendirme
            }

            // eğer entity varsa view'a gönder

            //Kategori içeriği dolu gelsin
            ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");

            return View(entity);
        }
    }
}