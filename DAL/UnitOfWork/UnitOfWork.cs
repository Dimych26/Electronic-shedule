using DAL.Entities;
using DAL.Interfaces;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repository;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private TableContext context;
        public UnitOfWork()
        {
            context = new TableContext();
        }

        private IGenericRepository<User> users;
        public IGenericRepository<User> Users
        {
            get
            {
                if (users == null)
                    users = new GenericRepository<User>(context);
                return users;
            }
        }

       

        private IGenericRepository<Teacher> teachers;
        public IGenericRepository<Teacher> Teachers
        {
            get
            {
                if (teachers == null)
                    teachers = new GenericRepository<Teacher>(context);
                return teachers;
            }
        }

        

        private IGenericRepository<Shedule> shedules;
        public IGenericRepository<Shedule> Shedules
        {
            get
            {
                if (shedules == null)
                    shedules = new GenericRepository<Shedule>(context);
                return shedules;
            }
        }

        


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
