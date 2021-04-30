﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AshburtonCocWebsite.Models;

namespace AshburtonCocWebsite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Media> Media { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<PrayerRequest> PrayerRequests { get; set; }
    }
}
