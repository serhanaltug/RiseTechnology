using Microsoft.EntityFrameworkCore;
using RT.Contacts.Domain.Entities;

namespace RT.Contacts.DataAccess.Concrete
{
    public class PostgreSqlEfDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"User ID=postgres;Password=sa;Server=localhost;Port=5432;Database=RiseTechContactsDb;Integrated Security=true;Pooling=true;");
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Contact>().HasKey(x => x.UUID);
            builder.Entity<Contact>().HasMany(x => x.IletisimBilgileri);
        }
    }
}