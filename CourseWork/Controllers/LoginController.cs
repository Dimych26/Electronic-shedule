using BLL.Interfaces;
using CourseWork.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CourseWork.Controllers
{
    public class LoginController : ApiController
    {
        public LoginController()
        {
            this.UserLogic = UIDependensyResolver<IUserLogic>.ResolveDependency();
        }
        IUserLogic UserLogic;
        // GET: api/Login
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Login/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        public void Post([FromBody]Wrap wrap)
        {
           
                UserLogic.Login(wrap.Login, wrap.Password);

        }

        // PUT: api/Login/5
        public void Put(int id, [FromBody]string value)
        {
        }
        [Route("api/Login/{Logout}")]
        [HttpPost]
        public void Logout()
        {
            UserLogic.Logout();
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }

        public class Wrap
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }
    }
}
