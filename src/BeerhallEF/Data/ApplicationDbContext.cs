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
        public DbSet<Location> Locations { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionstring = @"Server=.\SQLEXPRESS;Database=Beerhall;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionstring);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Brewer>(MapBrewer);
            modelbuilder.Entity<Beer>(MapBeer);
            modelbuilder.Entity<Location>(MapLocation);
            modelbuilder.Entity<Course>(MapCourse);
            modelbuilder.Entity<Category>(MapCategory);
            modelbuilder.Entity<CategoryBrewer>(MapCategoryBrewer);
            modelbuilder.Entity<OnlineCourse>(MapOnlineCourse);
            modelbuilder.Entity<OnsiteCourse>(MapOnsiteCourse);
        }

        private static void MapCategory(EntityTypeBuilder<Category> c)
        {
            //Properties
            c.Property(t => t.Name).HasMaxLength(100).IsRequired();
            c.Ignore(t => t.Brewers);
        }

        private static void MapCategoryBrewer(EntityTypeBuilder<CategoryBrewer> bc)
        {
            //Primary Key
            bc.HasKey(t => new { t.CategoryId, t.BrewerId });

            //Relations
            bc.HasOne(t => t.Category)
                .WithMany(t => t.CategoryBrewers)
                .HasForeignKey(t => t.CategoryId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            bc.HasOne(pt => pt.Brewer)
                .WithMany()
                .HasForeignKey(pt => pt.BrewerId)
                 .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

        }
        private static void MapCourse(EntityTypeBuilder<Course> c)
        {
            //Key
            c.HasKey(t => t.CourseId);

            //Properties
            c.Property(t => t.Title).HasMaxLength(100).IsRequired();

            //Inheritance : TPH, and renaming the discriminator
            c.HasDiscriminator<string>("Type")
                .HasValue<OnlineCourse>("Online")
               .HasValue<OnsiteCourse>("Onsite");
        }

        private void MapOnlineCourse(EntityTypeBuilder<OnlineCourse> c)
        {
            //Properties
            c.Property(t => t.Url).HasMaxLength(100);
        }

        private void MapOnsiteCourse(EntityTypeBuilder<OnsiteCourse> c)
        {
            //Properties
            c.Property(t => t.StartDate)
                .HasAnnotation("BackingField", "_startDate");
        }

        private static void MapLocation(EntityTypeBuilder<Location> l)
        {
            //Primary Key
            l.HasKey(t => t.PostalCode);

            //Properties
            l.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);
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

            b.HasOne(t => t.Location)
               .WithMany()
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            b.HasMany(t => t.Courses)
                .WithOne(t => t.Brewer)
                .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);

        }
    }
}