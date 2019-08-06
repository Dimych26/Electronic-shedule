using System.Collections.Generic;

namespace CourseWork.Models
{
    public class TeacherModel
    {
        public TeacherModel(string name, string login, string password)
        {
            // Departament = new ;
            Name = name;
            //Lessons = new List<LessonDTO>();
            Login = login;
            Password = password;
        }
        public TeacherModel()
        {

        }
        public int Id { get; set; }
       // public DepartmentModel Departament { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
       // public virtual List<LessonDTO> Lessons { get; set; }
    }
}