using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LoginRegister.Models
{
    public class myDbContext:DbContext
    {
      public DbSet<userAccount> userAccount { get; set; }
    }
}