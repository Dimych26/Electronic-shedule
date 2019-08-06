using BLL.Interfaces;
using BLL.Logic;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Util
{
    public class Binder : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserLogic>().To<UserLogic>();
           // Bind<ISheduleLogic>().To<SheduleLogic>();
           // Bind<IGroupLogic>().To<GroupLogic>();
           
        }
    }
}