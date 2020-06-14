using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ADP_HomeWork.DataBase.Tables
{
    [DataContract]
    public class News
    {
        public News()
        {
            Ranking = new Collection<Rank>();
        }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Abstract { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public string ImagePath { get; set; }
        [DataMember]
        public int TotalReads { get; set; }
        [DataMember]
        public ICollection<Rank> Ranking { get; set; }
        [DataMember]
        public int AgencyID { get; set; }
        [ForeignKey("AgencyID")]
        public Agency Agency { get; set; }


    }
}
