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
    public class RedactorController : ApiController
    {
        public RedactorController()
        {
            this.SheduleLogic = UIDependensyResolver<ISheduleLogic>.ResolveDependency();
        }
        ISheduleLogic SheduleLogic;


        IMapper SheduleControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<SheduleDTO, SheduleModel>();
            cfg.CreateMap<SheduleModel, SheduleDTO>();
        }).CreateMapper();
        // GET: api/Redactor
        public IEnumerable<SheduleModel> Get()
        {
            return SheduleControllerMapper.Map<IEnumerable<SheduleDTO>, IEnumerable<SheduleModel>>(SheduleLogic.GetAll());
        }

        // GET: api/Redactor/5
        public SheduleModel Get(int id)
        {
            return SheduleControllerMapper.Map<SheduleDTO, SheduleModel>(SheduleLogic.GetShedule(id));
        }

        // POST: api/Redactor
        public void Post([FromBody]SheduleModel value)
        {
            SheduleLogic.AddShedule(SheduleControllerMapper.Map<SheduleModel, SheduleDTO>(value));
        }

        // PUT: api/Redactor/5
        [HttpPut]
        public void Put(int id, [FromBody]SheduleModel value)
        {
           
            value.Id = id;
            SheduleLogic.Update(SheduleControllerMapper.Map<SheduleModel, SheduleDTO>(value));
        }

        // DELETE: api/Redactor/5
        public void Delete(int id)
        {
            SheduleLogic.DeleteShedule(id);
        }
    }
}
