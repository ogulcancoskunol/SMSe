using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSe.DAL.Repository.Interface;

namespace SMSe.DAL.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly SMSEntities context;
        private bool disposed;
        private Hashtable repositories;

        public UnitOfWork(SMSEntities context)
        {
            this.context = context;
        }

        public UnitOfWork()
        {
            context = new SMSEntities();
        }
        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    context.Dispose();

            disposed = true;
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories == null)
            {
                repositories = new Hashtable();
            }

            var type = typeof(T).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>).MakeGenericType(typeof(T));

                var repositoryInstance =
                     Activator.CreateInstance(repositoryType, context);

                repositories.Add(type, repositoryInstance);
            }

            return (IRepository<T>)repositories[type];
        }

        void IUnitOfWork.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
