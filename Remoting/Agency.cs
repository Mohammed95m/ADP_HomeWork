using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting
{
    [Serializable]
    public  class Agency
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int LanguageID { get; set; }
        public string LanguageName { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
