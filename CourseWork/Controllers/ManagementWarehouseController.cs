using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.ModelDTO;
using CourseWork.Util;
using BLL.Interfaces;
using AutoMapper;
using CourseWork.Models;
using DAL.Entities;

namespace CourseWork.Controllers
{
    public class ManagementWarehouseController : ApiController
    {
        public ManagementWarehouseController()
        {
            SheduleLogic = UIDependensyResolver<ISheduleLogic>.ResolveDependency();
        }
        ISheduleLogic SheduleLogic;

         IMapper ManagemantMap = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SheduleDTO, Shedule>();

            cfg.CreateMap<Shedule, SheduleDTO>();
           
        }).CreateMapper();

        // GET: api/ManagementWarehouse
        [Route("api/ManagementWarehouse/{GetTeacherShedule}/{id}")]
        [HttpGet]
        public IEnumerable<SheduleModel> GetTeacherShedule(int id)
        {
            return ManagemantMap.Map<IEnumerable<SheduleDTO>, IEnumerable<SheduleModel>>(SheduleLogic.GetTeachersSheduleAll(id));
        }
        [Route("api/ManagementWarehouse/GetGroupShedule/{group:int}")]
        [HttpGet]
        public IEnumerable<SheduleModel> GetGroupShedule(int group)
        {
            return ManagemantMap.Map<IEnumerable<SheduleDTO>, IEnumerable<SheduleModel>>(SheduleLogic.GetSheduleGroup(group));
        }
       
        [Route("api/ManagementWarehouse/GetAuditoryShedule/{number:int}")]
        [HttpGet]
        public IEnumerable<SheduleModel> GetAuditoryShedule(int number)
        {
            return ManagemantMap.Map<IEnumerable<SheduleDTO>, IEnumerable<SheduleModel>>(SheduleLogic.GetAutitoryShedule(number));
        }
        [Route("api/ManagementWarehouse/GetDisciplineShedule/{name:alpha}")]
        [HttpGet]
        public IEnumerable<SheduleModel> GetDisciplineShedule(string name)
        {
            return ManagemantMap.Map<IEnumerable<SheduleDTO>, IEnumerable<SheduleModel>>(SheduleLogic.GetDisciplineShedule(name));
        }
        // GET: api/ManagementWarehouse/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ManagementWarehouse
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ManagementWarehouse/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ManagementWarehouse/5
        public void Delete(int id)
        {
        }
    }
}
