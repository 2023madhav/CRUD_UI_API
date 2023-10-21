using FullStack.API.data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public CustomerController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAllCustomer()
        {
            var custmerlist = await _dbContext.Customers.ToListAsync();
            return Ok(custmerlist);
        }
        [HttpPost("Addcustomer")]
        public async Task<IActionResult> Addcustomer([FromBody] Customer customer)
        {
            customer.id = Guid.NewGuid();
            await _dbContext.Customers.AddAsync(customer);
            _dbContext.SaveChanges();
            return Ok(customer);
        }
        [HttpGet("Getcustomer/{id:Guid}")]
        public async Task<IActionResult> getcustomerByID([FromRoute] Guid id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.id == id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(customer);
            }
        }

        [HttpPut("Putcustomer/{id:Guid}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, Customer updatecustomer)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                customer.firstname = updatecustomer.firstname;
                customer.lastname = updatecustomer.lastname;
                customer.email = updatecustomer.email;
                customer.phone_Number = updatecustomer.phone_Number;
                customer.country_code = updatecustomer.country_code;
                customer.balance = updatecustomer.balance;
                customer.gender = updatecustomer.gender;
                await _dbContext.SaveChangesAsync();
                return Ok(customer);
            }
        }
        [HttpDelete("deletecustomer/{id:Guid}")]
        public async Task<IActionResult> Deletecustomer(Guid id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return Ok(customer);
            }
        }
    }
}
