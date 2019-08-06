using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ISheduleLogic
    {
        void AddShedule(SheduleDTO shedule);
        void DeleteShedule(int id);
        SheduleDTO GetShedule(int id);
        IEnumerable<SheduleDTO> GetAll();
        TeacherDTO LoadTeacherName(int id);
        void Update(SheduleDTO model);
        IEnumerable<SheduleDTO> GetSheduleGroup(int group);
        IEnumerable<SheduleDTO> GetAutitoryShedule(int number);

        IEnumerable<SheduleDTO> GetDisciplineShedule(string name);
        //SheduleDTO GetTeacherShedule(int id);
        IEnumerable<SheduleDTO> GetTeachersSheduleAll(int id);
        // TeacherDTO Login(string login, string password);
    }
}
