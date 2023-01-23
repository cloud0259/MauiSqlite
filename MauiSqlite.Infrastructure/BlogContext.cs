using MauiSqlite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqlite.Infrastructure
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog>? Blogs { get; set; }
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.Migrate();
            //Use to remove database
            //this.Database.EnsureDeletedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "blog.db");
            optionsBuilder.UseSqlite($"Data Source={sqlitePath}");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Blog>(e =>
            {
                e.Property(x => x.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
