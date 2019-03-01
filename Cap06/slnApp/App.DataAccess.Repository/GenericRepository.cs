using App.DataAccess.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository
{
    public class GenereicRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity:class
    {
        private AppDataModel _context;

        public GenereicRepository()
        {
            _context = new AppDataModel();
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

        public IEnumerable<TEntity> GetAll()
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            return query.ToList();
           
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
