using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelFinder.DataAccess
{
    public class HotelDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Server=DESKTOP-DV7066R\SQLEXPRESS;Database=Hotel2Db;Trusted_Connection=True");

        }
        public DbSet<Hotel> Hotels { get; set; }
    }
}
