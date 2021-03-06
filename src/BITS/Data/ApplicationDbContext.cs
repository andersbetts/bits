﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BITS.Models;

namespace BITS.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            //builder.Entity<IssueDescriptionItem>()
            //    .HasOne(idi => idi.Parent)
            //    .WithMany(idi => idi.Children)
            //    .HasForeignKey(idi => idi.ParentID)
            //    .OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<IssueDescriptionItem> IssueDescriptionItem { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<CustomerContact> CustomerContact { get; set; }

        public DbSet<Currency> Currency { get; set; }

        public DbSet<Tag> Tag { get; set; }
    }
}
