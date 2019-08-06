using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; } 
        public virtual Role Role { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        [MinLength(3)]
        public string Password { get; set; }
        
    }
}
