using Models.Model;
using System.Collections.Generic;


namespace DataAccessLayer.Abstract
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int Input);
        void AddCustomer(Customer customer);
        void DeleteCustomer(int Input);
        void UpdateCustomer(Customer customer, int Input);
    }
}
