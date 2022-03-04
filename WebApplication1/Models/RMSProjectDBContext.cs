using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace WebApplication1.Models
{
    public class RMSProjectDBContext : DbContext
    {
        public RMSProjectDBContext() : base("RMS-connections")
        {

        }
        public DbSet<Registration> Registrations { get; set; }
    }
}