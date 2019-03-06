using App.DataAccess.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository
{
    public class GenereicRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbContext _context;

        public GenereicRepository(DbContext pContext)
        {
            _context = pContext;
        }


        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public void Add(TEntity entity)
        {
            //Se agrega la entidad al contexto de Entity Framework
            _context.Set<TEntity>().Add(entity);

            //Se confirma la transaccion
            _context.SaveChanges();

            // return entity.ArtistId;

        }

        public TEntity FindEntity<TID>(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderby = null,
            string includeProperties = ""
            )
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split( new char[] {','},StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderby != null)
            {
                return orderby(query).ToList();
            }
            else
            {
                return query.ToList();
            }

            
           
        }

        public TEntity GetById<TId>(TId id)
        {
            //throw new NotImplementedException();
            return _context.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Set<TEntity>().Remove(entity);

            //Se confirma la transaccion
            var result = _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            //Se atacha la entidad al contexto de Entity Framework
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

            //Se confirma la transaccion
            var result = _context.SaveChanges();
        }
    }
}
