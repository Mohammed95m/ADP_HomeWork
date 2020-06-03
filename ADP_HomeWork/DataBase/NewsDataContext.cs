using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADP_HomeWork.DataBase.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ADP_HomeWork.DataBase
{
  
    public class NewsDataContext :DbContext
    {
        #region DbSets
        public DbSet<News> News { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<City> Cities { get; set; }
        #endregion
        private static DbContextOptions GetOptions( )
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                              .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();
            var ConnectionString =configuration.GetConnectionString("Local");

            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConnectionString).Options;
        }
        public NewsDataContext(DbContextOptions<NewsDataContext> options)
           : base(options)
        {
        }
        public NewsDataContext()
            : base(GetOptions())
        {
        }
    }
}
