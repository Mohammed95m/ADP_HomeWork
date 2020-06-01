using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Tables
{
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
        [ForeignKey("AgencyID")]
        public Agency Agency { get; set; }


    }
}
