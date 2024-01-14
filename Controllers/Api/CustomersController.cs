using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http.Extensions;
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
        private IMapper _mapper;

        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {

            return _context.Customers.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public ActionResult<CustomerDto> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.CustomerId = customer.CustomerId;
            return Created(new Uri(HttpContext.Request.GetDisplayUrl() + "/" + customer.CustomerId), customerDto);
        }

        // PUT /api/customers/1
        [HttpPut]
        public ActionResult<Customer> UpdateCustomer(int id, CustomerDto customerDto)
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
            _mapper.Map(customerDto, customerInDb);
            /* customerInDb.Name = customerDto.Name;
             customerDto.BirthDate = customerDto.BirthDate;
             customerDto.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;
             customerInDb.MembershipTypeId = customerDto.MembershipTypeId;*/
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
