using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP_HomeWork.DataBase.Tables
{
    public class Rank
    {
        public int ID { get; set; }
        public int Number { get; set; }

        public int NewsID { get; set; }
        [ForeignKey("NewsID")]
        public News News { get; set; }

    }
}
