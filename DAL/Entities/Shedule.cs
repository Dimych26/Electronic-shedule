using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Shedule
    {
        [Key]
       // [ForeignKey]
        public int id { get; set; }
        public int Pair { get; set; }
        public int Day { get; set; }
        public int Week { get; set; }
       // public virtual Teacher Teacher { get; set; }
       public virtual User User { get; set; }
        public int? UserId { get; set; }
        public string Discipline { get; set; }
        public int Auditorys_Number { get; set; }
        public int Group { get; set; }
    }
}
