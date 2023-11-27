namespace FormsApp.Models
{

    // hem liste hem de viewbag ile taşınan datayı almak için
    public class ProductViewModel
    {
        //null değil
        public List<Product> Products { get; set; } = null!;
        public List<Category> Categories { get; set; } = null!;
        public string? SelectedCategory { get; set; }

    }
}
