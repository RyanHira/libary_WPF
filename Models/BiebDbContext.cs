using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace Bieb.Models { 

public partial class BiebDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<BiebItem> BiebItems { get; set; }

    public BiebDbContext()
    {
    }

    public BiebDbContext(DbContextOptions<BiebDbContext> options)
        : base(options)
    {
    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // Connectie
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MKHJ4B1;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<Author>().HasData(
    new Author { Id = 1, Name = "Ron", },
    new Author { Id = 2, Name = "Polina",  },
    new Author { Id = 3, Name = "Tom",  });

            modelBuilder.Entity<BiebItem>().HasData(
         new { Id = 1, AuthorId = 1, Titel = "WPF is depricated", MediaType = "Book" },
         new { Id = 2, AuthorId = 2, Titel = "How do i seed this correctly for dummies", MediaType = "Book" },
         new { Id = 3, AuthorId = 3, Titel = "WPF is depricated a sequel", MediaType = "Book" }
     );
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
}