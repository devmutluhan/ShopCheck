using DataAccessLayer.Abstract;
using Models.Entities;
using Models.Model;
using System.Collections.Generic;

namespace BusinessLayer.Manager
{
    public class SalesManager
    {
        private readonly ISalesRepository salesRepository;
        private readonly IProductRepository productRepository;
        public SalesManager(ISalesRepository salesRepository, IProductRepository productRepository)
        {
            this.salesRepository = salesRepository;
            this.productRepository = productRepository;
        }
        public List<SalesDetail> GetSales()
        {
            return salesRepository.GetSales();
        }

        public SalesDetail GetSale(int Input)
        {
            return salesRepository.GetSale(Input);
        }

        public void Add(Sales sales)
        {
            salesRepository.AddSales(sales);
        }
        public void Delete(int Input)
        {
            var productId = salesRepository.GetProductId(Input);
            productRepository.AddStock(productId);
            salesRepository.DeleteSales(Input);
        }
        public void Update(Sales sales, int Input)
        {
            salesRepository.UpdateSales(sales, Input);
        }
    }
}
