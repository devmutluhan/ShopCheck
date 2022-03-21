using DataAccessLayer.Abstract;
using Models.Model;
using System.Collections.Generic;

namespace BusinessLayer.Manager
{
    public class CustomerManager
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerManager(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Add(Customer customer)
        {
            customerRepository.AddCustomer(customer);
        }

        public void Delete(int Input)
        {
            customerRepository.DeleteCustomer(Input);
        }

        public List<Customer> Get()
        {
            return customerRepository.GetCustomers();
        }
        public Customer Get(int Input)
        {
            return customerRepository.GetCustomer(Input);
        }

        public void Update(Customer customer, int Input)
        {
            customerRepository.UpdateCustomer(customer, Input);
        }
    }
}

