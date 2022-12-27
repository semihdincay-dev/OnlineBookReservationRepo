using System;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Models;

namespace LibraryAPI.Data
{
  public class LibraryContext : DbContext
  {
    public LibraryContext()
    {

    }
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer("Server=.;Database=LibraryDB;Trusted_Connection=true;TrustServerCertificate=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder
          .Entity<Book>()
          .Property(d => d.Id)
          .ValueGeneratedOnAdd();

      modelBuilder.Entity<Book>()
          .Property(b => b.Title)
          .IsRequired()
          .HasMaxLength(100);

      modelBuilder.Entity<Book>()
          .Property(b => b.Author)
          .IsRequired()
          .HasMaxLength(100);

      modelBuilder
          .Entity<User>()
          .Property(d => d.Id)
          .ValueGeneratedOnAdd();
      modelBuilder.Entity<User>()
          .Property(u => u.Name)
          .IsRequired()
          .HasMaxLength(100);

      modelBuilder
          .Entity<Reservation>()
          .Property(d => d.Id)
          .ValueGeneratedOnAdd();

      modelBuilder.Entity<Reservation>()
          .HasOne(r => r.User)
          .WithMany(u => u.Reservations)
          .HasForeignKey(r => r.UserId);

      modelBuilder.Entity<Reservation>()
          .HasOne(r => r.Book)
          .WithMany(b => b.Reservations)
          .HasForeignKey(r => r.BookId);

      modelBuilder.Entity<Book>()
        .HasData(
          new Book
          {
            Id = 1,
            Title = "To Kill a Mockingbird",
            Author = "Harper Lee",
            Amount = 10
          },
          new Book
          {
            Id = 2,
            Title = "The Catcher in the Rye",
            Author = "J.D. Salinger",
            Amount = 8

          },
          new Book
          {
            Id = 3,
            Title = "Pride and Prejudice",
            Author = "Jane Austen",
            Amount = 13
          });

      modelBuilder.Entity<User>()
        .HasData(
        new User
        {
          Id = 1,
          Name = "Semih DİNÇAY"
        },
        new User
        {
          Id = 2,
          Name = "Fatih DİNÇAY"
        });

      base.OnModelCreating(modelBuilder);
    }
  }
}
