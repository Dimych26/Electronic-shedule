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
    public class TeacherLogic : ITeacherLogic
    {
        IMapper TeacherMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Teacher, TeacherDTO>();
            cfg.CreateMap<TeacherDTO, Teacher>();
            cfg.CreateMap<Shedule, SheduleDTO>();
            cfg.CreateMap<SheduleDTO, Shedule>();
        }).CreateMapper();

        IUnitOfWork uow;

        public TeacherLogic()
        {
            uow = LogicDependencyResolver.ResolveUoW();
        }

        public TeacherLogic(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        public void AddTeacher(TeacherDTO user)
        {
            uow.Teachers.Create(TeacherMapper.Map<TeacherDTO, Teacher>(user));
        }

        public void DeleteTeacher(int id)
        {
            uow.Teachers.Remove(id);
        }

        public IEnumerable<TeacherDTO> GetAll()
        {
            return TeacherMapper.Map<IEnumerable<Teacher>,List<TeacherDTO>>(uow.Teachers.GetAll());
        }

        public IEnumerable<SheduleDTO> GetSheduleGroup(int group)
        {
            return TeacherMapper.Map<IEnumerable<Shedule>, IEnumerable<SheduleDTO>>(uow.Shedules.Get(sh => sh.Group == group));
        }

        public TeacherDTO GetTeacher(int id)
        {
            return TeacherMapper.Map<Teacher, TeacherDTO>(uow.Teachers.GetOne(t => t.Id == id));
        }

        public IEnumerable<SheduleDTO> GetTeachersSheduleAll(int id)
        {
            return TeacherMapper.Map<IEnumerable<Shedule>, List<SheduleDTO>>(uow.Shedules.Get(sh => sh.UserId == id));
        }

        public TeacherDTO Login(string login, string password)
        {
            TeacherDTO teacher = TeacherMapper.Map<Teacher, TeacherDTO>(uow.Teachers.Get(t => t.Login == login && t.Password == password).FirstOrDefault());
            if (teacher == null)
                throw new Exception("Try again");
            return teacher;
        }
    }
}
