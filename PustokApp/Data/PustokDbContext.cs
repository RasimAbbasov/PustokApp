using Microsoft.EntityFrameworkCore;
using PustokApp.Models;

namespace PustokApp.Data
{
    public class PustokDbContext:DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTags { get; set; }
        public PustokDbContext(DbContextOptions<PustokDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PustokDbContext).Assembly);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added) 
                {
                    entry.Entity.CreateDate = DateTime.Now;
                }
                if(entry.State == EntityState.Modified)
                {
                    //if (entry.Property(p=>p.IsDelete).CurrentValue == true)
                    //{
                    //    entry.Entity.UpdateDate = DateTime.Now;
                    //}
                    entry.Entity.UpdateDate = DateTime.Now;
                }
             
            }
            return base.SaveChanges();
        }
    }
}
