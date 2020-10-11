using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Models
{
    public class SpaContext : DbContext
    {
        public SpaContext(DbContextOptions<SpaContext> options) : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Services> Services { get; set; }
        public DbSet<Contact> Clients { get; set; }

        public DbSet<Services> ClientServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Services>().HasData(
                new Services { ID = 1, Name = "Full-Day Treatment Package", Classification = "Full", Fee = 450 },
                new Services { ID = 2, Name = "Half-Day Treatment Package", Classification = "Half", Fee = 300 },
                new Services { ID = 3, Name = "Two-Hour Treatment Package", Classification = "Two", Fee = 225 },
                new Services { ID = 4, Name = "One-Hour Treatment Package", Classification = "One", Fee = 100 },
                new Services { ID = 5, Name = "Custom Treatment Package", Classification = "Other" },
                new Services { ID = 6, Name = "Haircut or Trim", Classification = "Cut", Fee = 45 },
                new Services { ID = 7, Name = "Full Foil Color", Classification = "Color", Fee = 100 }
                );
            modelBuilder.Entity<Contact>().HasData(
               new Contact { ID = 1, Name = "Wilma Flintstone", ServicesID = 1, ContactEmail = "wilma@flint.net" },
               new Contact { ID = 2, Name = "Barney Rubble", ServicesID = 7, ContactEmail = "Barn@rubb.com" },
               new Contact { ID = 3, Name = "Betty Rubble", ServicesID = 5, ContactEmail = "betts@rubb.com" }
               );
            modelBuilder.Entity<Client>().HasData(
new Client { ID = 1, FirstName = "Flo", LastName = "Schmoe", Username = "Flo", Email = "flo@schmoe.net", Password = "FloSchmoe1234*" },
new Client { ID = 2, FirstName = "Jo", LastName = "Schmoe", Username = "JoJo", Email = "jojo@schmoe.net", Password = "JoJoSchmoe1234?" },
new Client { ID = 3, FirstName = "Truly", LastName = "Schmoe", Username = "Truly", Email = "truly@schmoe.net", Password = "Truly9876**" }
);
            modelBuilder.Entity<ClientService>().HasData(
            new ClientService { ID = 1, ClientID = 1, ServicesID = 1 },
            new ClientService { ID = 2, ClientID = 2, ServicesID = 7 },
            new ClientService { ID = 3, ClientID = 1, ServicesID = 5 }
            );
        }

        public DbSet<RazorPages.Models.Client> Client { get; set; }

        public DbSet<RazorPages.Models.ClientService> ClientService { get; set; }
    }
}
