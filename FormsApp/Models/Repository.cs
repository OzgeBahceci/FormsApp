namespace FormsApp.Models
{
    public class Repository
    {
        //Hem product hem Category Repositorysi
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {

        }

        public static  List<Product> Products
        {
            //private olan _products böylelikle public olup sadece get methodu yazıldı
            //set olmadığı için değiştirilemiyor, sadece erişim
            get
            {
                return _products;
            }
        }

        public static List<Category> Categories
        {
            //private olan _products böylelikle public olup sadece get methodu yazıldı
            //set olmadığı için değiştirilemiyor, sadece erişim
            get
            {
                return _categories;
            }
        }
    }
}
