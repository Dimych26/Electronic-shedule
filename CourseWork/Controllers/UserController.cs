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
    public class UserController : ApiController
    {
        IUserLogic UserLogic;
        
        public UserController(IUserLogic userLogic)
        {
            UserLogic = userLogic;
        }

        public UserController()
        {
            UserLogic = UIDependensyResolver<IUserLogic>.ResolveDependency();
        }

        IMapper UserControllerMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<UserDTO, UserModel>();
            cfg.CreateMap<UserModel, UserDTO>();
        }).CreateMapper();

        // GET: api/User
        public IEnumerable<UserModel> Get()//повертає всіх users з бази даних
        {

            return UserControllerMapper.Map<IEnumerable<UserDTO>, IEnumerable<UserModel>>(UserLogic.GetAll());
        }

        // GET: api/User/5
        public UserModel Get(int id)// повертає одного user за id
        {
            return UserControllerMapper.Map<UserDTO, UserModel>(UserLogic.GetUser(id));
        }

        // POST: api/User
        public void Post([FromBody]UserModel value)//додавання нового user
        {
            UserLogic.AddUser(UserControllerMapper.Map<UserModel, UserDTO>(value));
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]UserModel value)//do this
        {
            value.Id = id;
            UserLogic.Update(UserControllerMapper.Map<UserModel,UserDTO>(value));
        }

        // DELETE: api/User/5
        public void Delete(int id)//видалення user
        {
            UserLogic.DeleteUser(id);
        }
    }
}
