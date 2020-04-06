using Microsoft.EntityFrameworkCore;
namespace ContactBook.API.Models
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        {
        }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<ContactGroups> ContactGroups{get;set;}
    }
    
}