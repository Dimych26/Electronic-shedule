using DAL.Context;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private TableContext db;
        private DbSet<T> dbSet;

        public GenericRepository(TableContext tableContext)
        {
            db = tableContext;
            dbSet = db.Set<T>();
        }

        public void Create(T item)
        {
            dbSet.Add(item);
            db.SaveChanges();
        }

        public T FindById(int id)
        {
            return dbSet.Find(id);
        }


        public IEnumerable<T> Get(Func<T, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public T GetOne(Func<T, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).FirstOrDefault();
        }

        public void Remove(int id)
        {
            dbSet.Remove(dbSet.Find(id));
            db.SaveChanges();
        }

        public void Update(T item)
        {
            // db.Entry(db.Set<T>().Find(id)).CurrentValues.SetValues(item);
            try

            {
                
                
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();

            }

         catch (DbUpdateConcurrencyException ex)

            {

                var data = ex.Entries.Single();

                data.OriginalValues.SetValues(data.GetDatabaseValues());

            }
            
        }

        

        #region IDisposable Support
        private bool disposedValue = false; // Для определения избыточных вызовов

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: освободить управляемое состояние (управляемые объекты).
                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить ниже метод завершения.
                // TODO: задать большим полям значение NULL.

                disposedValue = true;
            }
        }

        // TODO: переопределить метод завершения, только если Dispose(bool disposing) выше включает код для освобождения неуправляемых ресурсов.
        // ~GenericRepository() {
        //   // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
        //   Dispose(false);
        // }

        // Этот код добавлен для правильной реализации шаблона высвобождаемого класса.
        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки выше, в методе Dispose(bool disposing).
            Dispose(true);
            // TODO: раскомментировать следующую строку, если метод завершения переопределен выше.
            // GC.SuppressFinalize(this);
        }

        




        #endregion


    }
}
