using Microsoft.EntityFrameworkCore;
using RevolutionFactory.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevolutionFactory.Data
{
    public class RevolutionFactoryDbContext : DbContext
    {
        public RevolutionFactoryDbContext(DbContextOptions options) : base(options)
        {
                
        }
        public DbSet<Tweet> Tweets { get; set; }
    }
}
