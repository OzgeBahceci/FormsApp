namespace FormsApp.Models
{
    public class Repository
    {
        //Hem product hem Category Repositorysi
        private static readonly List<Product> _products = new();
        private static readonly List<Category> _categories = new();

        static Repository()
        {
            _categories.Add(new Category { CategoryId = 1, Name = "Telefon" });
            _categories.Add(new Category { CategoryId = 2, Name = "Bilgisayar" });

            _products.Add(new Product { ProductId = 1, Name = "Iphone 14", Price = 40000, IsActive = true, Image = "1.jpg", CategoryId = 1 });
            _products.Add(new Product { ProductId = 2, Name = "Iphone 15", Price = 50000, IsActive = true, Image = "2.jpg", CategoryId = 1 });
            _products.Add(new Product { ProductId = 3, Name = "Iphone 16", Price = 60000, IsActive = true, Image = "3.jpg", CategoryId = 1 });
            _products.Add(new Product { ProductId = 4, Name = "Iphone 17", Price = 70000, IsActive = true, Image = "4.jpg", CategoryId = 1 });
           
            _products.Add(new Product { ProductId = 5, Name = "Macbook Air", Price = 80000, IsActive = true, Image = "5.jpg", CategoryId = 2 });
            _products.Add(new Product { ProductId = 6, Name = "Macbook Pro", Price = 70000, IsActive = true, Image = "6.jpg", CategoryId = 2 });

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

        public static void CreateProduct(Product product)
        {
            _products.Add(product);
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

        public static void EditProduct(Product updatedProduct)
        {
			//updatedProduct güncellenmiş product nesnesi
			// bu id tüm product listesinde ara eşleşeni geri döndür
			var entity = _products.FirstOrDefault(p => p.ProductId == updatedProduct.ProductId);
			if (entity != null)
			{
				if (!string.IsNullOrEmpty(updatedProduct.Name))
				{
					entity.Name = updatedProduct.Name;
				}
				entity.Price = updatedProduct.Price;
				entity.Image = updatedProduct.Image;
				entity.CategoryId = updatedProduct.CategoryId;
				entity.IsActive = updatedProduct.IsActive;
			}
		}
	}
}
