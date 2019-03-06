using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository.Interface
{
    public interface IGenericRepository<TEntity>
        where TEntity:class
    {
        void Add(TEntity entity);
        int Count();

        TEntity GetById<TID>( TID iD);

        //TEntity FindEntity<TID>(TID entity);

        TEntity FindEntity<TID>(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity,bool>> filter=null,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> orderby=null,
            string includeProperties=""
            );
        void Update(TEntity entity);
        void Remove(TEntity entity);

    }
}
