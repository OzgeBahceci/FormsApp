using System.ComponentModel.DataAnnotations;

namespace FormsApp.Models
{
    public class Product
    {
        //İsmini çekerken görünecek olan isim
        [Display(Name = "Ürün Id")]
        public int ProductId { get; set; }

        //public string? Name { get; set; } ile aynı
        [Display(Name = "Ürün Adı")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        public bool IsActive { get; set; }


        //Hangi ürün hangi kategoriye ait
        public int CategoryId { get; set; }

    }
}
