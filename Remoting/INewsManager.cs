using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting
{
   public interface INewsManager
    {
        bool Add(News news);
        bool Remove(int newsID);
        bool UpdatePhoto(int newsID, string image, string extention);
        ICollection<News> GetAll();
        News GetNews(int newsID);
        ICollection<News> GetByAgency(int agencyID);

    }
 
}
