﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using vega2.Models;

namespace vega2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Properties

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }  
        public DbSet<Feature> Features { get; set; }              

        #endregion

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
        }
    }
}
