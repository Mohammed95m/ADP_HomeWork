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
        bool UpdatePhoto(int newsID,string imagePath);
        ICollection<News> GetAll();
        ICollection<News> GetByAgency(int agencyID);

    }
}
