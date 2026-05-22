using Poc.DeliveryContinu.ServiceValidation.Models;
using Microsoft.EntityFrameworkCore;
 

namespace Poc.DeliveryContinu.ServiceValidation.Data
{
    public class ValidationDbContext:DbContext
    {
        public ValidationDbContext(DbContextOptions<ValidationDbContext> options)
           : base(options)
        {
            
        }
        public DbSet<Validation> Validations { get; set; }
       
    }
}
   
