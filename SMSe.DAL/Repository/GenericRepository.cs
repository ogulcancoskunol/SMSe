using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SMSe.DAL.Repository.Interface;

namespace SMSe.DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {


        private SMSEntities context;
        private DbSet<TEntity> dbSet;

        public GenericRepository()
        {
            context = new SMSEntities();
        }

        public GenericRepository(SMSEntities context)
        {
            this.context = context ?? throw new ArgumentNullException("context");
            dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }

            dbSet.Add(instance);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = this.dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public void Update(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                dbSet.Attach(instance);
                context.Entry(instance).State = EntityState.Modified;
            }
        }

        public void Delete(TEntity instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                if (context.Entry(instance).State == EntityState.Detached)
                {
                    dbSet.Attach(instance);
                }
                dbSet.Remove(instance);
            }
        }
    }
}
