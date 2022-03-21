using Dapper;
using DataAccessLayer.Abstract;
using Models.Model;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class CustomerRepository : BaseRepository,ICustomerRepository
    {
        public CustomerRepository(Settings settings) : base(settings.ConnectionString)
        {

        }
        public List<Customer> GetCustomers()
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Customer>("Select*From Customer").OrderBy(x=>x.CustomerId).ToList();
            }
        }
        public Customer GetCustomer(int Input)
        {
            using (var connection = GetConnection())
            {
                return connection.Query<Customer>("Select*From Customer Where CustomerId='" + Input + "'").FirstOrDefault();
            }
        }
        public void AddCustomer(Customer customer)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("Insert Into Customer (Name,Surname,Phone,Address) Values (@Name,@Surname,@Phone,@Address)", customer);
            }
        }
        public void DeleteCustomer(int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute("Delete From Customer Where CustomerId='" + Input + "'");
            }
        }
        public void UpdateCustomer(Customer customer, int Input)
        {
            using (var connection = GetConnection())
            {
                connection.Execute(@"Update Customer Set 
                    Name=@Name,
                    Surname=@Surname,
                    Phone=@Phone,
                    Address=@Address 
                    Where CustomerId='" + Input + "'", customer);
            }
        }
    }
}
