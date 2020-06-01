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
            if(IsInit) _context.SaveChanges();
        }
    }
}
