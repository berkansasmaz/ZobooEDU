using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Zoboo.Entity
{
    public class ZBDBContext :  IdentityDbContext<ZBUser, IdentityRole<Guid>, Guid>
    {
          public ZBDBContext(DbContextOptions options) : base(options)
      	  {
     	   }

    }
}