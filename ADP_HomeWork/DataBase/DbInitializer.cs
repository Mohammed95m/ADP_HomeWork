using ADP_HomeWork.DataBase.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP_HomeWork.DataBase
{
    public static class DbInitializer
    {
        public static void Initialize(this NewsDataContext _context)
        {

            _context.Database.EnsureCreated();
            bool IsInit = false;
            if (!_context.Cities.Any())
            {
                _context.Cities.Add(new  City { Name = "Lattakia" });
                _context.Cities.Add(new  City { Name = "Aleppo" });
                _context.Cities.Add(new  City { Name = "Damascus" });
                _context.Cities.Add(new  City { Name = "Homs" });
                IsInit = true;
            }
            if (!_context.Languages.Any())
            {
                _context.Languages.Add(new  Language { Name = "English",Code="en" });
                _context.Languages.Add(new  Language { Name = "Arabic",Code="ar" });
                IsInit = true;
            }
            if (!_context.Agencies.Any())
            {
                var cityId =  _context.Cities.FirstOrDefault().ID;
                var languageID = _context.Languages.FirstOrDefault().ID;
                var agency1 = new Agency { Name = "Roetarez", CityID = cityId, LanguageID = languageID };
                var agency2 = new Agency { Name = "sana", CityID = cityId, LanguageID = languageID };
                _context.Agencies.Add(agency1);
                _context.Agencies.Add(agency2);

                if (!_context.News.Any())
                {
                    _context.News.Add(new News
                    {
                        Abstract = "test test",
                        Agency = agency1,
                        Date = DateTime.Now,
                        Text="test test test test test"
                        

                    });
                    _context.News.Add(new News
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
          
            if (IsInit) _context.SaveChanges();
        }
    }
}
