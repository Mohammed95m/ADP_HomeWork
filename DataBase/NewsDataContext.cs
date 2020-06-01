using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase.Tables;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class NewsDataContext :DbContext
    {
        #region DbSets
        public DbSet<News> News { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<City> Cities { get; set; }
        #endregion
        public NewsDataContext(DbContextOptions<NewsDataContext> options)
           : base(options)
        {
        }
    }
}
