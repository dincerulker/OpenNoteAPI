using Microsoft.EntityFrameworkCore;

namespace OpenNoteAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>().HasData(
                new Note() { Id = 1, Title = "Sample Note 1", Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quasi, incidunt?" },
                new Note() { Id = 2, Title = "Sample Note 2", Content = "Odit iure quos quidem voluptate accusamus non officia maiores vero." },
                new Note() { Id = 3, Title = "Sample Note 3", Content = "Quos saepe tempora ipsam deserunt corrupti ipsum minima obcaecati minus." },
                new Note() { Id = 4, Title = "Sample Note 4", Content = "Possimus mollitia dolore placeat nisi nostrum cumque corrupti iste inventore!" }
                );
        }
    }
}
