using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using road_to_asp.Data;
using road_to_asp.Dtos;
using road_to_asp.Models;

namespace road_to_asp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            var customers = _context.Customers.ToList();
            return customers.Select(c => Mapper.Map<Customer, CustomerDto>);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

        // POST /api/customers
        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        // PUT /api/customers/1
        [HttpPut]
        public ActionResult<Customer> UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            customerInDb.Name = customer.Name;
            customer.BirthDate = customer.BirthDate;
            customer.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();

            return customerInDb;
        }

        // DELETE /api/customer/1
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {

            var customerInDb = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
            {
                return NotFound();
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok(new { message = $"Customer {customerInDb.Name} deleted successfully" });

        }


    }
}
