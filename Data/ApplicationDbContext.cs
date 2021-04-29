using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<AshburtonCocWebsite.Models.Media> Media { get; set; }
        public DbSet<AshburtonCocWebsite.Models.Article> Articles { get; set; }
        public DbSet<AshburtonCocWebsite.Models.PrayerRequest> PrayerRequests { get; set; }
    }
}
