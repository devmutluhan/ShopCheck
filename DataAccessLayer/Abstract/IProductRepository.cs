using Models.Model;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface IProductRepository
    {
        List<Product> GetProduct();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void DeleteProduct(int Input);
        void UpdateProduct(Product product, int Input);
        void DeleteStock(int Input);
        void AddStock(int Input);
    }
}
