using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GroupB_A2.Models;

namespace GroupB_A2.Data
{
    public class BusinessContext : DbContext
    {

        public BusinessContext (DbContextOptions<BusinessContext> options)
            : base(options)
        {
        }

        public DbSet<GroupB_A2.Models.Business> Business { get; set; } = default!;

        public DbSet<GroupB_A2.Models.Category>? Category { get; set; }
        
    }
    
    
}
