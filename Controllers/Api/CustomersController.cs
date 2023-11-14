﻿using Microsoft.AspNetCore.Mvc;
using road_to_asp.Data;
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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        // GET /api/customers/1
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

        // DELET /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.Single(c => c.CustomerId == id);
            if (customerInDb == null)
            {
                throw new Ex
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return customerInDb;


        }


    }
}
