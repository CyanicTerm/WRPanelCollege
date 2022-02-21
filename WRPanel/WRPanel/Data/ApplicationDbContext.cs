using Microsoft.EntityFrameworkCore;
using WRPanel.Models;

namespace WRPanel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
    }
}
