using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ADP_HomeWork.DataBase;
using ADP_HomeWork.DataBase.Tables;

namespace WCFService
{
    
    public class NewsService : INewsService
    {
        public bool AddRank(int ID, int Rank)
        {
     
            if (ID <= 0) return false;
            using (var _context = new NewsDataContext())
            {
                var news = _context.News.SingleOrDefault(s => s.ID == ID);
                if (news != null)
                {
                    _context.Ranks.Add(new ADP_HomeWork.DataBase.Tables.Rank { NewsID = ID, Number = Rank });
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<News> GetBestNegative(int n)
        {
            using (var _context = new NewsDataContext())
            {

                return _context.News
                .Include("Agency")
                     .Include("Ranking")
                   .OrderBy(s => s.Ranking.Select(a=>a.Number).Sum()).Take(n).ToList();
            }
        }

        public List<News> GetBestPositive(int n)
        {
            using (var _context = new NewsDataContext())
            {
                return _context.News
                .Include("Agency")
                .Include("Ranking")
                 .OrderBy(s => s.Ranking.Select(a => a.Number).Sum()).Take(n).ToList();
            }
        }

        public List<News> GetLast10()
        {
            using (var _context = new NewsDataContext())
            {
                return _context.News
                .Include("Agency")
                   .OrderByDescending(s => s.Date).Take(10).ToList();
            }
        }

        public News GetSimilar(string title , string Abstract)
        {
            using (var _context = new NewsDataContext())
            {
                if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(Abstract))
                {
                    return _context.News
               .Include("Agency")
                  .FirstOrDefault(s => s.Title == title
                   || s.Abstract == Abstract);
                }
                else
                {
                    if (!string.IsNullOrEmpty(title))
                    {
                        return _context.News
                      .Include("Agency")
                     .FirstOrDefault(s => s.Title == title);
                    }
                    else if (!string.IsNullOrEmpty(Abstract))
                    {
                        return _context.News
                 .Include("Agency")
                   .FirstOrDefault(s => s.Abstract == Abstract);
                    }
                    return null;
                }
               
            }
        }
    }
}
