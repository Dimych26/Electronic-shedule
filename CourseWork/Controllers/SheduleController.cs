using AutoMapper;
using BLL.Interfaces;
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
    public class SheduleController : ApiController
    {
        public SheduleController()
        {
            SheduleLogic = UIDependensyResolver<ISheduleLogic>.ResolveDependency();
        }
        ISheduleLogic SheduleLogic;

        
         IMapper SheduleControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SheduleDTO, SheduleModel>();
            cfg.CreateMap<SheduleModel, SheduleDTO>();
        }).CreateMapper();
        // GET: api/Shedule
        public IEnumerable<SheduleModel> Get()
        {
            return SheduleControllerMapper.Map<IEnumerable<SheduleDTO>, IEnumerable<SheduleModel>>(SheduleLogic.GetAll());
        }



        // GET: api/Shedule/5
        //public string Get(int id)
        //{
        //    return "value";
        //}
        [Route("api/Shedule/{GetTeacherShedule}/{id}")]
        [HttpGet]
        public IEnumerable<SheduleModel> GetTeacherShedule(int id)
        {
            return SheduleControllerMapper.Map<IEnumerable<SheduleDTO>, IEnumerable<SheduleModel>>(SheduleLogic.GetTeachersSheduleAll(id));
        }

       

        // POST: api/Shedule
        public void Post([FromBody]SheduleModel value)
        {     
            SheduleLogic.AddShedule(SheduleControllerMapper.Map<SheduleModel,SheduleDTO>(value));
        }

        // PUT: api/Shedule/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shedule/5
        public void Delete(int id)
        {
            SheduleLogic.DeleteShedule(id);
        }
    }
}
