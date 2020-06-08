using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADP_HomeWork.DataBase.Tables;
 

namespace ADP_HomeWork.DataBase
{
  
    public class NewsDataContext :DbContext
    {
        public NewsDataContext() : base(ConnectionString)
        {
            Database.SetInitializer<NewsDataContext>(new CreateDatabaseIfNotExists<NewsDataContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }
        public static string ConnectionString { get; set; } = "Server=.;Database=ADP_HomeWork;Trusted_Connection=True;MultipleActiveResultSets=true";
        #region DbSets
        public DbSet<News> News { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<City> Cities { get; set; }
        #endregion
 
    }
}
