using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using road_to_asp.Data;
using road_to_asp.Models;
using road_to_asp.Services;
using road_to_asp.ViewModels;

namespace road_to_asp.Controllers
{

    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Route("customers/AllCustomers")]
        public IActionResult AllCustomers()
        {


            var customers = _context.Customers.Include(c => c.MembershipType).ToList();


            var viewModel = new CustomersViewModel()
            {
                Customers = customers
            };
            return View(viewModel);
        }
        [Route("customer/details/{id}")]
        public IActionResult Details(int? id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var viewModel = new CustomersViewModel();

            var customer = customers.FirstOrDefault(c => c.CustomerId == id);

            if (customer != null)
            {
                viewModel.Customers.Add(customer);
                return View(viewModel);
            }
            return NotFound();
        }
        public IActionResult New(){

            var membershipTypes = _context.MembershipTypes.ToList();
           
            var viewModel = new CustomerFormViewModel 
            {
            MembershipTypes = membershipTypes,
            Customer = new Customer()
            };

            return View("CustomerForm",viewModel);
        }
        [HttpPost] 
        public IActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("AllCustomers", "Customers");
        }

        public IActionResult Edit( int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList(),
            };
            return View("CustomerForm", viewModel);
            
        }


    }

}
