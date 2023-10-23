using Microsoft.AspNetCore.Mvc;
using road_to_asp.Models;
using road_to_asp.Services;
using road_to_asp.ViewModels;

namespace road_to_asp.Controllers
{

    public class CustomersController : Controller
    {
        [Route("customers/AllCustomers")]
        public IActionResult AllCustomers()
        {
          

            var customers = new CustomerList().GetCustomers();


            var viewModel = new CustomersViewModel()
            {
                Customers = customers
            };
            return View(viewModel);
        }
        [Route("customer/details/{id}")]
        public IActionResult Details(int? id)
        {
            var customers = new CustomerList().GetCustomers();
            var viewModel = new CustomersViewModel();

            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer != null)
            {
                viewModel.Customers.Add(customer);
                return View(viewModel);
            }
            return NotFound();




        }


    }

}
