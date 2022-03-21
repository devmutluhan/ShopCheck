using DataAccessLayer.Abstract;
using Models.Model;
using System.Collections.Generic;

namespace BusinessLayer.Manager
{
    public class ProductManager
    {
        private readonly IProductRepository productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Add(Product product)
        {
            productRepository.AddProduct(product);
        }

        public void Delete(int Input)
        {
            productRepository.DeleteProduct(Input);
        }

        public List<Product> Get()
        {
            return productRepository.GetProduct();
        }
        public Product Get(int Input)
        {
            return productRepository.GetProduct(Input);
        }

        public void Update(Product product, int Input)
        {
            productRepository.UpdateProduct(product, Input);
        }
        public void DeleteStock(int Input)
        {
            productRepository.DeleteStock(Input);
        }
        public void AddStock(int Input)
        {
            productRepository.AddStock(Input);
        }
    }
}
