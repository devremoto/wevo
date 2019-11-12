using Data.EF.Mappings;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public partial class AppDbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Person> Persons { get; set; }

	private static void Map(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new LanguageMap());
            modelBuilder.ApplyConfiguration(new PersonMap());
        }
	}
}
