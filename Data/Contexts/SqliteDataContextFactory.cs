using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contexts;

public class SqliteDataContextFactory : IDesignTimeDbContextFactory<SqliteDataContext>
{
    public SqliteDataContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddUserSecrets<SqliteDataContextFactory>()
            .Build();


        var optionsBuilder = new DbContextOptionsBuilder<SqliteDataContext>();
        optionsBuilder.UseSqlite(configuration.GetConnectionString("LocalDb"));

        return new SqliteDataContext(optionsBuilder.Options);
    }
}
