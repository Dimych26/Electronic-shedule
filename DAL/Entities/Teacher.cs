using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
       // public Department Departament { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
       
        //public virtual List<Group> Groups { get; set; }
        //public virtual List<Lesson> Lessons { get; set; }
    }
}
