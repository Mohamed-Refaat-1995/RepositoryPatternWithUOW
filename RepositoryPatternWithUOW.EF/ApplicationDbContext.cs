using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RepositoryPatternWithUOW.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUOW.EF
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { set; get; }
        public DbSet<Author> Authors { set; get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>().HasData(new[]
            {
                new Author
                {
                    Id = 1,
                    Name = "Mohamed"

                },
                new Author
                {
                    Id = 2,
                    Name = "Ahmed"

                },
                new Author
                {
                    Id = 3,
                    Name = "Amira"

                },
                new Author
                {
                    Id = 4,
                    Name = "Aya"

                }
            });
            modelBuilder.Entity<Book>().HasData(new[]
            {
                new Book
                {
                    Id = 1,
                    Title = "Book1",
                    AuthorId=1

                },
                new Book
                {
                    Id = 2,
                    Title = "Book2",
                    AuthorId=2

                },
                new Book
                {
                    Id = 3,
                    Title = "Book4",
                    AuthorId=4

                },
                new Book
                {
                    Id = 4,
                    Title = "Book1",
                    AuthorId=1

                }
            });

            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(r => r.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

    }
}
