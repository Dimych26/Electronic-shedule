using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTO
{
   public class TeacherDTO
    {
        public TeacherDTO(string name, string login, string password)
        {
           // Departament = new ;
            Name = name;
            //Lessons = new List<LessonDTO>();
            Login = login;
            Password = password;
        }
        public TeacherDTO()
        {
                
        }
        public int Id { get; set; }
       // public DepartmentDTO Departament { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
       // public virtual List<LessonDTO> Lessons { get; set; }
    }
}
