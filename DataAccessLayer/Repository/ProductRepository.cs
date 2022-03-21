using Dapper;
using DataAccessLayer.Abstract;
using Models.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(Settings settings) : base(settings.ConnectionString)
        {

        }
        public List<Product> GetProduct()
        {
            using (var connection = GetConnection())
            {
                return GetConnection().Query<Product>("Select*From Product", GetConnection()).OrderBy(x=>x.ProductId).ToList();
            }
        }
        public Product GetProduct(int id)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Product>(@"Select*From Product 
                Where ProductId='" + id + "'").FirstOrDefault();
            }
        }
        public void AddProduct(Product product)
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@"Insert Into Product (ProductName,Price,Stock) 
                Values (@ProductName,@Price,@Stock)", product);
            }
        }
        public void DeleteProduct(int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("Delete From Product Where ProductId='" + Input + "'");
            }
        }
        public void UpdateProduct(Product product, int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("Update Product Set ProductName=@ProductName,Price=@Price,Stock=@Stock Where ProductId='" + Input + "'", product);
            }
        }
        public void DeleteStock(int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("Update Product Set Stock=Stock-1 Where ProductId='" + Input + "'");
            }
        }
        public void AddStock(int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("Update Product Set Stock=Stock+1 Where ProductId = '" + Input + "'");
            }
        }
    }
}
