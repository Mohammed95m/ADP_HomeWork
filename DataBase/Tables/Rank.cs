using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ADP_HomeWork.DataBase.Tables
{
    [DataContract]
    public class Rank
    {
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public int NewsID { get; set; }
        [ForeignKey("NewsID")]
        public News News { get; set; }

    }
}
