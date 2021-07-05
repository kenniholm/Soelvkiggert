using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SubscriberAPI.Models
{
    public class SubscriberAPIContext : DbContext
    {
        public SubscriberAPIContext (DbContextOptions<SubscriberAPIContext> options)
            : base(options)
        {
        }

        public DbSet<SubscriberAPI.Models.SubscriberProduct> SubscriberProduct { get; set; }
    }
}
