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
        public Agency()
        {
            Console.WriteLine("{0}:{1}:{2}:{3}", DateTime.Now.Hour.ToString(),
                DateTime.Now.Minute.ToString(), DateTime.Now.Second.ToString(),
                DateTime.Now.Millisecond.ToString());
            Console.WriteLine("Agency.Constructor: object created");
        }
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
