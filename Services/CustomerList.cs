using road_to_asp.Data;
using road_to_asp.Models;

namespace road_to_asp.Services
{
    public class CustomerList
    {
        private List<Customer> _Customers;
        public CustomerList()
        {
            this._Customers = new List<Customer>
            {
             new Customer {Name = "John Smith",CustomerId = 1 },
            new Customer{Name = "Robert Smith" ,CustomerId = 2 }
            };
        }
        public List<Customer> GetCustomers()
        {
            return _Customers;
        }
    }
}
