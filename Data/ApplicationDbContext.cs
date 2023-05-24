using ECBank.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace ECBank.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options) { }

        public ApplicationDbContext()
        {
        }

        public DbSet<LoanApplication> LoanApplication { get; set; }
    }
}
