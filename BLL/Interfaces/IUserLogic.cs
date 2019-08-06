using BLL.ModelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserLogic
    {
        void AddUser(UserDTO user);
        void DeleteUser(int id);
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetAll();
        UserDTO Login(string login, string password);
        void Update(UserDTO user);
        void Logout();
    }
}
