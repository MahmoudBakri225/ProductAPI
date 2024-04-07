using ProductAPI.Data;
using ProductAPI.IRepository;
using ProductAPI.Model;


namespace ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        ApplicationDbContext context;

        public ProductRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product Update(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
            return product; 
        }


        public bool Delete(int id)
        {
            var product = GetById(id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
                return true; 
            }
            return false; 
        }
    }
}
