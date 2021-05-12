using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace CriadoresCaes_tA_B.Data {
   public class ApplicationDbContext : IdentityDbContext {

      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options) {
      }



   }
}
