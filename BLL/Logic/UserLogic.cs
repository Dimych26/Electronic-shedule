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
    public class UserLogic : IUserLogic
    {
        public static UserDTO CurrentUser;
        static UserLogic()
        {
            CurrentUser = null;
        }
        IMapper UserMapper = new MapperConfiguration(cfg =>
          {
              cfg.CreateMap<User, UserDTO>();
              cfg.CreateMap<UserDTO, User>();
          }).CreateMapper();

        IUnitOfWork uow;

        public UserLogic()
        {
            uow = LogicDependencyResolver.ResolveUoW();
        }

        public UserLogic(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public void AddUser(UserDTO user)
        {
            if(CurrentUser == null)
                throw new Exception("You are not registered");
            else if (CurrentUser.Role.RoleName != "Administrator")
                throw new Exception("You do not have access");
            uow.Users.Create(UserMapper.Map<UserDTO, User>(user));
        }

        public void DeleteUser(int id)
        {
            if (CurrentUser == null)
                throw new Exception("You are not registered");
            else if (CurrentUser.Role.RoleName != "Administrator")
                throw new Exception("You do not have access");
            uow.Users.Remove(id);
        }

        public IEnumerable<UserDTO> GetAll()
        {
            if (CurrentUser == null)
                throw new Exception("You are not registered");
            else if (CurrentUser.Role.RoleName != "Administrator")
                throw new Exception("You do not have access");
            return UserMapper.Map<IEnumerable<User>, List<UserDTO>>(uow.Users.GetAll());
        }

        public UserDTO GetUser(int id)
        {
            if (CurrentUser == null)
                throw new Exception("You are not registered");
            else if (CurrentUser.Role.RoleName != "Administrator")
                throw new Exception("You do not have access");
            return UserMapper.Map<User,UserDTO>(uow.Users.GetOne(user=>user.Id==id));
        }

        public UserDTO Login(string login, string password)
        {
            UserDTO user = UserMapper.Map<User, UserDTO>(uow.Users.GetOne(u => u.Login == login && u.Password == password));//.FirstOrDefault());
            if (user == null)
                throw new Exception("Invalid login password combination");
            CurrentUser = user;
            return user;
        }
        public void Logout()
        {
            CurrentUser = null;
        }

        public void Update(UserDTO user)
        {
            uow.Users.Update(UserMapper.Map<UserDTO, User>(user));
        }
    }
}
