using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SMSe.DAL.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity instance);
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetById(object id);

        void Update(TEntity instance);

        void Delete(TEntity instance);
    }
}
