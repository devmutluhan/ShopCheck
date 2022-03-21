using Dapper;
using DataAccessLayer.Abstract;
using Models.Entities;
using Models.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class SalesRepository : BaseRepository, ISalesRepository
    {
        public SalesRepository(Settings settings) : base(settings.ConnectionString)
        {

        }

        public int GetProductId(int id)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<int>("Select ProductId From Sales Where SalesId='" + id + "'").FirstOrDefault();
            }
        }
        public List<SalesDetail> GetSales()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<SalesDetail>(@"Select
                    c.Name,
                    c.Surname,
                    c.Phone,
                    p.ProductName,
                    ı.Type,
                    p.Price*ı.Komisyon [Price],
                    s.SalesId
                    From Customer c 
                    Inner Join Sales s on c.CustomerId=s.CustomerId
                    Inner Join Product p on p.ProductId=s.ProductId
                    Inner Join Installment ı on ı.InstallmentId=s.InstallmentId").OrderBy(x=>x.SalesId).ToList();
            }

        }
        public SalesDetail GetSale(int Input)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<SalesDetail>($@"Select
                    c.Name,
                    c.Surname,
                    c.Phone,
                    p.ProductName,
                    ı.Type,
                    p.Price*ı.Komisyon [Price],
                    s.SalesId
                    From Customer c 
                    Inner Join Sales s on c.CustomerId=s.CustomerId
                    Inner Join Product p on p.ProductId=s.ProductId
                    Inner Join Installment ı on ı.InstallmentId=s.InstallmentId
                    Where s.SalesId = {Input} ").FirstOrDefault();
            }
        }
        public void AddSales(Sales sales)
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@"Insert Into Sales (CustomerId,InstallmentId,ProductId,SalesDate) 
                        Values (@CustomerId,@InstallmentId,@ProductId,@SalesDate)", sales);
            }
        }
        public void DeleteSales(int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("Delete From Sales Where SalesId='" + Input + "'");
            }
        }
        public void UpdateSales(Sales sales, int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@"Update Sales Set 
                    CustomerId=@CustomerId,
                    SalesDate=@SalesDate,
                    InstallmentId=@InstallmentId,
                    ProductId=@ProductId 
                    Where SalesId='" + Input + "'", sales);
            }
        }
    }
}
