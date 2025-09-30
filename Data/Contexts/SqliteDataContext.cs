using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts;

public class SqliteDataContext(DbContextOptions options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<SessionEntity> Sessions { get; set; } = null!;
}
