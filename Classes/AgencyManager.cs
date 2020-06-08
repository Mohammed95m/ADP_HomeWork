using ADP_HomeWork.DataBase;
 
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.EntityFrameworkCore;
using Remoting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ADP_HomeWork.Classes
{

    public class AgencyManager : MarshalByRefObject, IAgencyManager
    {
        public AgencyManager()
        {
        }
     
        public bool Add(Agency agency)
        {
            if (agency != null)
            {
                using (var _context = new NewsDataContext())
                {
                    _context.Agencies.Add(new DataBase.Tables.Agency
                    {
                        CityID = agency.CityID,
                        LanguageID = agency.LanguageID,
                        Name = agency.Name
                    });
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool Update(Agency agency)
        {
            if (agency == null) return false;
            if (agency.ID <= 0) return false;
            using (var _context = new NewsDataContext())
            {
                var Agency = _context.Agencies.SingleOrDefault(s => s.ID == agency.ID);
                if (Agency == null) return false;
                Agency.CityID = agency.CityID;
                Agency.LanguageID = agency.LanguageID;
                Agency.Name = agency.Name;
                _context.SaveChanges();
                return true;
            }
        }

        public Agency getByID(int agencyID)
        {
            using (var _context = new NewsDataContext())
            {
                return _context.Agencies.Include(s => s.Language)
                 .Include(s => s.City)
                 .Select(s => new Agency
                 {
                     ID = s.ID,
                     CityID = s.CityID,
                     CityName = s.City.Name,
                     LanguageID = s.LanguageID,
                     LanguageName = s.Language.Name,
                     Name = s.Name
                 })
                 .SingleOrDefault(s => s.ID == agencyID);
            }
        }

        public Agency getByName(string agencyName)
        {
            using (var _context = new NewsDataContext())
            {
                return _context.Agencies.Include(s => s.Language)
                  .Include(s => s.City)
                  .Select(s => new Agency
                  {
                      ID = s.ID,
                      CityID = s.CityID,
                      CityName = s.City.Name,
                      LanguageID = s.LanguageID,
                      LanguageName = s.Language.Name,
                      Name = s.Name
                  })
                  .SingleOrDefault(s => s.Name == agencyName);
            }
        }

        ICollection<Agency> IAgencyManager.GetAll()
        {
            using (var _context = new NewsDataContext())
            {
                return _context.Agencies.Include(s => s.Language)
                 .Include(s => s.City)
                 .Select(s => new Agency
                 {
                     ID = s.ID,
                     CityID = s.CityID,
                     CityName = s.City.Name,
                     LanguageID = s.LanguageID,
                     LanguageName = s.Language.Name,
                     Name = s.Name
                 })
                 .ToArray();
            }
        }

        public bool Remove(int agencyID)
        {
            using (var _context = new NewsDataContext())
            {
                if (agencyID <= 0) return false;
                var Agency = _context.Agencies.SingleOrDefault(s => s.ID == agencyID);
                if (Agency == null) return false;
                _context.Agencies.Remove(Agency);
                _context.SaveChanges();
                return true;
            }
        }



        ICollection<DataEntriy> IAgencyManager.GetCities()
        {
            using (var _context = new NewsDataContext())
            {
                return _context.Cities.Select(s => new DataEntriy
                {
                    ID = s.ID,
                    Name = s.Name
                }).ToArray();
            }
        }

        ICollection<DataEntriy> IAgencyManager.GetLanguages()
        {
            using (var _context = new NewsDataContext())
            {
                return _context.Languages.Select(s => new DataEntriy
                {
                    ID = s.ID,
                    Name = s.Name
                }).ToArray();
            }
        }
    }
}
