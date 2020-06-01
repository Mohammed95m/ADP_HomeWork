using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remoting
{
    [Serializable]
    public class News
    {
         
         public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public int TotalReads { get; set; }
        public int Ranking { get; set; }
        public int AgencyID { get; set; }
        public string Agency { get; set; }


    }
}
