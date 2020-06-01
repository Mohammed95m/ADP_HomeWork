using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting
{
  public  interface IAgencyManager
    {
        bool Add(Agency agency);
        bool Update(Agency agency);
        bool Remove(int agencyID);
        Agency getByID(int agencyID);
        Agency getByName(string agencyName);
        ICollection<Agency> GetAll();
    }
}
