using AutoMapper;
using BLL.Interfaces;
using BLL.Logic;
using BLL.ModelDTO;
using CourseWork.Models;
using CourseWork.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourseWork.Controllers
{
    public class TeacherController : ApiController
    {

        public TeacherController()
        {
            SheduleLogic = UIDependensyResolver<ISheduleLogic>.ResolveDependency();
        }
        //ITeacherLogic TeacherLogic;
        ISheduleLogic SheduleLogic;

        IMapper TeacherControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<TeacherDTO,TeacherModel>();
            cfg.CreateMap<TeacherModel, TeacherDTO>();
            cfg.CreateMap<SheduleModel, SheduleDTO>();
            cfg.CreateMap<SheduleDTO, SheduleModel>();
        }).CreateMapper();
        
        [Route("api/Teacher/GetTeacherShedule/{id}")]
        [HttpGet]
        public IEnumerable<SheduleModel> GetTeacherShedule(int id)
        {
            return TeacherControllerMapper.Map<IEnumerable<SheduleDTO>, IEnumerable<SheduleModel>>(SheduleLogic.GetTeachersSheduleAll(id));
        }
        [Route("api/Teacher/GetSheduleGroup/{group:int}")]
        [HttpGet]
        public IEnumerable<SheduleModel> GetSheduleGroup(int group)
        {
            return TeacherControllerMapper.Map<IEnumerable<SheduleDTO>, IEnumerable<SheduleModel>>(SheduleLogic.GetSheduleGroup(group));
        }
        
        public void Put(int id, [FromBody]string value)
        {
        }

        
    }
}
