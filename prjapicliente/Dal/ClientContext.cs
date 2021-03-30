using Microsoft.EntityFrameworkCore;
using prjapicliente.Models;
namespace prjapicliente.Dal
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions<ClientContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasOne(a => a.Address);
            base.OnModelCreating(modelBuilder);
        }

    }
}
