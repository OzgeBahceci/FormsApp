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
        [Required(ErrorMessage= "Gerekli bir alan")]
        //maks 100 karakterlik bir isim
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Range(0,100000)]
        [Display(Name = "Fiyatı")]
        public decimal? Price { get; set; }

        [Required]
        [Display(Name = "Resim")]
        public string? Image { get; set; }


        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }

        [Required]
        [Display(Name = "Kategori")]
        //Hangi ürün hangi kategoriye ait
        public int? CategoryId { get; set; }

    }
}
