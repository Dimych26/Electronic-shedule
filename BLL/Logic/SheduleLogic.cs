using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.ModelDTO;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Logic
{
    public class SheduleLogic : ISheduleLogic
    {
         IMapper SheduleMapp = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SheduleDTO, Shedule>();

            cfg.CreateMap<Shedule, SheduleDTO>();
           
        }).CreateMapper();
        
        IUnitOfWork uow;

        public SheduleLogic()
        {
            uow = LogicDependencyResolver.ResolveUoW();
        }

        public SheduleLogic(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public void AddShedule(SheduleDTO shedule)
        {
            uow.Shedules.Create(SheduleMapp.Map<SheduleDTO, Shedule>(shedule));
        }

        public void DeleteShedule(int id)
        {
            uow.Shedules.Remove(id);
        }

        public IEnumerable<SheduleDTO> GetAll()
        {
            if (UserLogic.CurrentUser == null)
                throw new Exception("You are not registered");
            return SheduleMapp.Map<IEnumerable<Shedule>, List<SheduleDTO>>(uow.Shedules.GetAll()
                .OrderBy(sh => sh.Week)
                .OrderBy(sh => sh.Day)
                .OrderBy(sh => sh.Pair));
        }

        public SheduleDTO GetShedule(int id)
        {
            if (UserLogic.CurrentUser == null)
                throw new Exception("You are not registered");
            return SheduleMapp.Map<Shedule, SheduleDTO>(uow.Shedules.GetOne(sh => sh.id == id));
        }

        public IEnumerable<SheduleDTO> GetTeachersSheduleAll(int id)
        {
            if (UserLogic.CurrentUser == null)
                throw new Exception("You are not registered");
            else if (UserLogic.CurrentUser.Role.RoleName == "User")
                throw new Exception("You do not have access");
            return SheduleMapp.Map<IEnumerable<Shedule>, List<SheduleDTO>>(uow.Shedules.Get(sh => sh.UserId == id)
                .OrderBy(sh => sh.Week)
                .OrderBy(sh => sh.Day)
                .OrderBy(sh => sh.Pair));
        }
        

        public TeacherDTO LoadTeacherName(int id)
        {
            return SheduleMapp.Map<Teacher,TeacherDTO>(uow.Teachers.FindById(id));
        }

        public void Update(SheduleDTO model)
        {
            uow.Shedules.Update(SheduleMapp.Map<SheduleDTO,Shedule>(model));
        }

        public IEnumerable<SheduleDTO> GetSheduleGroup(int group)
        {
            if (UserLogic.CurrentUser == null)
                throw new Exception("You are not registered");
            
            return SheduleMapp.Map<IEnumerable<Shedule>, IEnumerable<SheduleDTO>>(uow.Shedules.Get(sh => sh.Group == group)
                .OrderBy(sh=>sh.Week)
                .OrderBy(sh=>sh.Day)
                .OrderBy(sh=>sh.Pair));
        }

        public IEnumerable<SheduleDTO> GetAutitoryShedule(int number)
        {
            if (UserLogic.CurrentUser == null)
                throw new Exception("You are not registered");
            else if (UserLogic.CurrentUser.Role.RoleName != "Redactor" || UserLogic.CurrentUser.Role.RoleName != "Management")
                throw new Exception("You do not have access");
            return SheduleMapp.Map<IEnumerable<Shedule>, IEnumerable<SheduleDTO>>(uow.Shedules.Get(sh => sh.Auditorys_Number == number)
                .OrderBy(sh => sh.Week)
                .OrderBy(sh => sh.Day)
                .OrderBy(sh => sh.Pair));
        }

        public IEnumerable<SheduleDTO> GetDisciplineShedule(string name)
        {
            if (UserLogic.CurrentUser == null)
                throw new Exception("You are not registered");
            else if (UserLogic.CurrentUser.Role.RoleName != "Redactor" || UserLogic.CurrentUser.Role.RoleName != "Management")
                throw new Exception("You do not have access");
            return SheduleMapp.Map<IEnumerable<Shedule>, IEnumerable<SheduleDTO>>(uow.Shedules.Get(sh => sh.Discipline == name)
                .OrderBy(sh => sh.Week)
                .OrderBy(sh => sh.Day)
                .OrderBy(sh => sh.Pair));
        }
    }
}
