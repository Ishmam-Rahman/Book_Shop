using BookStroe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStroe.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }
        public DbSet<BookModel> BookModel{ get; set;}
        public DbSet<BookType> BookType { get; set; }

        //protected override void OnModelCreating(Modelbuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BookType>()
        //        .HasMany(e => e.BookModel)
        //        .WithOne(c => c.booktype);
        //}
    }
}
