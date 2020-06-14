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
    public class Agency
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }

        public int LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public Language Language { get; set; }
    }
}
