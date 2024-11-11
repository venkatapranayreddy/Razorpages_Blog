using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razorpages.Models; 

namespace Razorpages.Data
{
    public class BlogDBContext : DbContext
    {
         public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPost { get; set; }
        // public DbSet<Tag> Tags { get; set; }
    }
}