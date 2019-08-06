using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseWork.Models
{
    public class SheduleModel
    {
        
        public int Id { get; set; }

        public int Pair { get; set; }
       
        public int Day { get; set; }
       
        public int Week { get; set; }
        // public virtual TeacherModel Teacher { get; set; }
       
        public virtual UserModel User { get; set; }
        
        public int? UserId { get; set; }
       
        public string Discipline { get; set; }
        
        public int Group { get; set; }
        //public int Department { get; set; }
        
        public string UserName { get; set; }
        
        public string UserSurname { get; set; }
       // public string TeacherPatronymic { get; set; }
        public int Auditorys_Number { get; set; }
    }
}