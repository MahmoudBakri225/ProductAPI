using ProductAPI.Model;

namespace ProductAPI.IRepository
{
    public interface IProductRepository
    {
        void Create(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        Product Update(Product product);
        bool Delete(int id);
    }
}
