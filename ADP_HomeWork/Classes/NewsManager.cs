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

    public class NewsManager : MarshalByRefObject, INewsManager
    {
 
        public NewsManager()
        {
 
        }
        public bool Add(News news)
        {
            if(news!=null)
            {
                using (var _context = new NewsDataContext())
                {
                    var News = new DataBase.Tables.News
                    {
                        Abstract = news.Abstract,
                        AgencyID = news.AgencyID,
                        Date = DateTime.Now,
                        Ranking = news.Ranking,
                        Text = news.Text,
                        Title = news.Title
                    };
                    _context.News.Add(News);
                    if (news?.Image?.Length > 0)
                    {
                        Byte[] bytes = Convert.FromBase64String(news.Image);
                        var uploadpath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\", "Images\\");
                        Directory.CreateDirectory(uploadpath);
                        string filename = Guid.NewGuid().ToString() + news.ImageExtenttion;
                        File.WriteAllBytes(Path.Combine(uploadpath, filename), bytes);
                        News.ImagePath = uploadpath + filename;
                    }
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public ICollection<News> GetAll()
        {
            using (var _context = new NewsDataContext())
            {
                return _context.News
                .Include(s => s.Agency)
                .Select(s => new Remoting.News
                {
                    ID = s.ID,
                    Abstract = s.Abstract,
                    AgencyID = s.AgencyID,
                    Agency = s.Agency.Name,
                    Date = s.Date,
                    ImagePath = s.ImagePath,
                    Text = s.Text,
                    Ranking = s.Ranking,
                    Title = s.Title,
                    TotalReads = s.TotalReads
                }).OrderByDescending(s => s.Date).Take(10).ToArray();
            }
        }
        public  News  GetNews(int newsID)
        {
            using (var _context = new NewsDataContext())
            {
                return _context.News
                .Include(s => s.Agency)
                .Select(s => new Remoting.News
                {
                    ID = s.ID,
                    Abstract = s.Abstract,
                    AgencyID = s.AgencyID,
                    Agency = s.Agency.Name,
                    Date = s.Date,
                    ImagePath = s.ImagePath,
                    Text = s.Text,
                    Ranking = s.Ranking,
                    Title = s.Title,
                    TotalReads = s.TotalReads
                })?.SingleOrDefault(s => s.ID == newsID);
            }
        }

        public ICollection<News> GetByAgency(int agencyID)
        {
            using (var _context = new NewsDataContext())
            {
                return _context.News
               .Include(s => s.Agency)
               .Select(s => new Remoting.News
               {
                   ID = s.ID,
                   Abstract = s.Abstract,
                   AgencyID = s.AgencyID,
                   Agency = s.Agency.Name,
                   Date = s.Date,
                   ImagePath = s.ImagePath,
                   Text = s.Text,
                   Ranking = s.Ranking,
                   Title = s.Title,
                   TotalReads = s.TotalReads
               }).OrderByDescending(s => s.Date).Where(s => s.AgencyID == agencyID).ToArray();
            }
            }

        public bool Remove(int newsID)
        {
            if (newsID <= 0) return false;
            using (var _context = new NewsDataContext())
            {
                var news = _context.News.SingleOrDefault(s => s.ID == newsID);
                _context.News.Remove(news);
                _context.SaveChanges();
            }
            return true;
        }

        public bool UpdatePhoto(int newsID, string image, string extention)
        {
            if (newsID <= 0) return false;
            using (var _context = new NewsDataContext())
            {
                var news = _context.News.SingleOrDefault(s => s.ID == newsID);
                if (news != null)
                {
                    if (image?.Length > 0)
                    {
                        Byte[] bytes = Convert.FromBase64String(image);
                        var uploadpath = Path.Combine(Directory.GetCurrentDirectory() + "\\wwwroot\\", "Images\\");
                        Directory.CreateDirectory(uploadpath);
                        string filename = Guid.NewGuid().ToString() + extention;
                        File.WriteAllBytes(Path.Combine(uploadpath, filename), bytes);
                        news.ImagePath = uploadpath + filename;
                        _context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
           
            return false;
        }
    }
}
