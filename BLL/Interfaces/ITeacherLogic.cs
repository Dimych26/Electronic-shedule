using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITeacherLogic
    {
        void AddTeacher(TeacherDTO user);
        void DeleteTeacher(int id);
        TeacherDTO GetTeacher(int id);
        IEnumerable<TeacherDTO> GetAll();
        TeacherDTO Login(string login, string password);
        IEnumerable<SheduleDTO> GetSheduleGroup(int group);
        IEnumerable<SheduleDTO> GetTeachersSheduleAll(int id);
    }
}
