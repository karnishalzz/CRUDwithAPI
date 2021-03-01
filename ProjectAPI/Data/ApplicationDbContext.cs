using Microsoft.EntityFrameworkCore;
using ProjectAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ProjectAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }
    }
}
