﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BeerhallEF.Data;

namespace BeerhallEF.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeerhallEF.Models.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd();

                    b.Property<double?>("AlcoholByVolume");

                    b.Property<int?>("BrewerId")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<decimal>("Price");

                    b.HasKey("BeerId");

                    b.HasIndex("BrewerId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("BeerhallEF.Models.Brewer", b =>
                {
                    b.Property<int>("BrewerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactEmail")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime?>("DateEstablished");

                    b.Property<string>("Description");

                    b.Property<string>("LocationPostalCode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("BrewerName")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Street")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int?>("Turnover");

                    b.HasKey("BrewerId");

                    b.HasIndex("LocationPostalCode");

                    b.ToTable("Brewers");
                });

            modelBuilder.Entity("BeerhallEF.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BeerhallEF.Models.CategoryBrewer", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("BrewerId");

                    b.HasKey("CategoryId", "BrewerId");

                    b.HasIndex("BrewerId");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryBrewer");
                });

            modelBuilder.Entity("BeerhallEF.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BrewerId")
                        .IsRequired();

                    b.Property<int?>("Credits");

                    b.Property<int>("Language");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Type")
                        .IsRequired();

                    b.HasKey("CourseId");

                    b.HasIndex("BrewerId");

                    b.ToTable("Courses");

                    b.HasDiscriminator<string>("Type").HasValue("Course");
                });

            modelBuilder.Entity("BeerhallEF.Models.Location", b =>
                {
                    b.Property<string>("PostalCode");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("PostalCode");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("BeerhallEF.Models.OnlineCourse", b =>
                {
                    b.HasBaseType("BeerhallEF.Models.Course");

                    b.Property<string>("Url")
                        .HasAnnotation("MaxLength", 100);

                    b.ToTable("OnlineCourse");

                    b.HasDiscriminator().HasValue("Online");
                });

            modelBuilder.Entity("BeerhallEF.Models.OnsiteCourse", b =>
                {
                    b.HasBaseType("BeerhallEF.Models.Course");

                    b.Property<TimeSpan?>("From");

                    b.Property<int>("NumberOfDays");

                    b.Property<DateTime>("StartDate")
                        .HasAnnotation("BackingField", "_startDate");

                    b.Property<TimeSpan?>("Till");

                    b.ToTable("OnsiteCourse");

                    b.HasDiscriminator().HasValue("Onsite");
                });

            modelBuilder.Entity("BeerhallEF.Models.Beer", b =>
                {
                    b.HasOne("BeerhallEF.Models.Brewer")
                        .WithMany("Beers")
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeerhallEF.Models.Brewer", b =>
                {
                    b.HasOne("BeerhallEF.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationPostalCode");
                });

            modelBuilder.Entity("BeerhallEF.Models.CategoryBrewer", b =>
                {
                    b.HasOne("BeerhallEF.Models.Brewer", "Brewer")
                        .WithMany()
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BeerhallEF.Models.Category", "Category")
                        .WithMany("CategoryBrewers")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BeerhallEF.Models.Course", b =>
                {
                    b.HasOne("BeerhallEF.Models.Brewer", "Brewer")
                        .WithMany("Courses")
                        .HasForeignKey("BrewerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
