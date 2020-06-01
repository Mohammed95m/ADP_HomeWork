using Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADP_HomeWork.Classes
{
    public class NewsManager : MarshalByRefObject, INewsManager
    {
        public bool Add(News news)
        {
            throw new NotImplementedException();
        }

        public ICollection<News> GetAll()
        {
            throw new NotImplementedException();
        }

        public ICollection<News> GetByAgency(int agencyID)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int newsID)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePhoto(int newsID, string imagePath)
        {
            throw new NotImplementedException();
        }
    }
}
