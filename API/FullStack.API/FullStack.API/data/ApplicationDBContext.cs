using FullStack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
