using road_to_asp.Models;

namespace road_to_asp.ViewModels
{
    public class CustomersViewModel
    {
        public List<Customer> Customers { get; set; }

        public CustomersViewModel()
        {
            Customers = new List<Customer>();
        }

    }

}

