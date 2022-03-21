using Models.Entities;
using Models.Model;
using System.Collections.Generic;

namespace DataAccessLayer.Abstract
{
    public interface ISalesRepository
    {
        int GetProductId(int id);
        List<SalesDetail> GetSales();
        SalesDetail GetSale(int Input);
        void AddSales(Sales sales);
        void DeleteSales(int Input);
        void UpdateSales(Sales sales, int Input);
    }
}
