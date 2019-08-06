using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ModelDTO
{
    public class UserDTO
    {
        public UserDTO() { }
        public UserDTO(string name,string surname,string login,string password)
        {
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; }
        public virtual RoleDTO Role { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
