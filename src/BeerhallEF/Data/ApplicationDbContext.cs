using BeerhallEF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BeerhallEF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Brewer> Brewers { get; set; }
        public DbSet<Beer> Beers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring = @"Server=.\SQLEXPRESS;Database=Beerhall;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Brewer>(MapBrewer);
            modelbuilder.Entity<Beer>(MapBeer);
        }

   
        private void MapBeer(EntityTypeBuilder<Beer> b)
        {
           // Properties
            b.Property(t => t.Name).IsRequired().HasMaxLength(100);
        }

        private static void MapBrewer(EntityTypeBuilder<Brewer> b)
        {
            //Mappen tabel
            b.ToTable("Brewers");

            //Mappen Primary key
            b.HasKey(t => t.BrewerId);

            //Properties
            b.Property(t => t.Name)
                .HasColumnName("BrewerName")
                .IsRequired()
                .HasMaxLength(100);

            b.Property(t => t.ContactEmail)
                .HasMaxLength(100);

            b.Property(t => t.Street)
                .HasMaxLength(100);

            b.Property(t => t.BrewerId)
                .ValueGeneratedOnAdd();

            //Associations
            b.HasMany(t => t.Beers)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            
       
        }
    }
}