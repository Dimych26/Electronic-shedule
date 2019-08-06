using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; }  //получение доступа к репозиториям
       
        IGenericRepository<Teacher> Teachers { get; }
        IGenericRepository<Shedule> Shedules { get; }
        void Save();
        void Dispose();
    }
}
