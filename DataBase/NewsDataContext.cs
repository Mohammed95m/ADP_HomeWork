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
            Seed();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            base.OnModelCreating(modelBuilder);
        }
        public static string ConnectionString { get; set; } = "Server=.;Database=ADP_HomeWork;Trusted_Connection=True;MultipleActiveResultSets=true";
        #region DbSets
        public DbSet<News> News { get; set; }
        public DbSet<Rank>  Ranks { get; set; }
        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<City> Cities { get; set; }
        #endregion
       public void Seed()
        {
            this.Database.CreateIfNotExists();
            bool IsInit = false;
            if (!this.Cities.Any())
            {
                this.Cities.Add(new City { Name = "Lattakia" });
                this.Cities.Add(new City { Name = "Aleppo" });
                this.Cities.Add(new City { Name = "Damascus" });
                this.Cities.Add(new City { Name = "Homs" });
                IsInit = true;
                this.SaveChanges();
            }
            if (!this.Languages.Any())
            {
                this.Languages.Add(new Language { Name = "English", Code = "en" });
                this.Languages.Add(new Language { Name = "Arabic", Code = "ar" });
                IsInit = true;
                this.SaveChanges();
            }
            if (!this.Agencies.Any())
            {
                var cityId = this.Cities.FirstOrDefault().ID;
                var languageID = this.Languages.FirstOrDefault().ID;
                var agency1 = new Agency { Name = "Roetarez", CityID = cityId, LanguageID = languageID };
                var agency2 = new Agency { Name = "sana", CityID = cityId, LanguageID = languageID };
                this.Agencies.Add(agency1);
                this.Agencies.Add(agency2);

                if (!this.News.Any())
                {
                    this.News.Add(new News
                    {
                        Abstract = "test test",
                        Agency = agency1,
                        Date = DateTime.Now,
                        Text = "test test test test test"


                    });
                    this.News.Add(new News
                    {
                        Abstract = "test 2 test 2",
                        Agency = agency2,
                        Date = DateTime.Now,
                        Text = "test 2 test 2 test 2 test 2 test 2"


                    });


                    IsInit = true;
                }
                IsInit = true;
            }

            if (IsInit) this.SaveChanges();
        }
    }
}
