using BLL.Interfaces;
using BLL.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseWork.Util
{
    public static class UIDependensyResolver<T>
    {
        public static dynamic ResolveDependency()
        {
            if (typeof(T) == typeof(IUserLogic))
                return new UserLogic();
            
            else if (typeof(T) == typeof(ITeacherLogic))
                return new TeacherLogic();
            else if (typeof(T) == typeof(ISheduleLogic))
                return new SheduleLogic();
           
            
            else return null;
        }
    }
}