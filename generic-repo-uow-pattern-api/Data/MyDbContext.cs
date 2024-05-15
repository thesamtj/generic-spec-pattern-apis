﻿using generic_repo_uow_pattern_api.Entity;
using static generic_repo_uow_pattern_api.Data.MyDbContext;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace generic_repo_uow_pattern_api.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
           .HasOne(o => o.Product)
           .WithMany(p => p.Orders)
           .HasForeignKey(o => o.ProductId);
        }
    }
}
