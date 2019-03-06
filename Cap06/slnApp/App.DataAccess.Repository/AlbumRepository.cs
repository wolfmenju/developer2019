using App.DataAccess.Repository.Interface;
using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess.Repository
{
    public class AlbumRepository : GenereicRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(DbContext context) : base(context)
        {

        }
       //private AppDataModel _context;

        //public ArtistRepository()
        //{
        //    _context = new AppDataModel();
        //}


        //public int Count()
        //{
        //    return _context.Artist.Count();
        //}

        //public void Add(Artist entity)
        //{
        //    //Se agrega la entidad al contexto de Entity Framework
        //    _context.Artist.Add(entity);

        //    //Se confirma la transaccion
        //    _context.SaveChanges();

        //   // return entity.ArtistId;

        //}

        //public IEnumerable<Artist> GetAll()
        //{
        //    IQueryable<Artist> query = _context.Artist;
        //    return query.ToList();
           
        //}

        //public Artist GetById<TID>(TID id)
        //{
        //    //throw new NotImplementedException();
        //    return _context.Artist.Find(id);
        //}

        //public void Remove(Artist entity)
        //{
        //    _context.Artist.Attach(entity);
        //    _context.Artist.Remove(entity);

        //    //Se confirma la transaccion
        //    var result = _context.SaveChanges();
        //}

        //public void Update(Artist entity)
        //{
        //    //Se atacha la entidad al contexto de Entity Framework
        //    _context.Artist.Attach(entity);
        //    _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

        //    //Se confirma la transaccion
        //    var result = _context.SaveChanges();
        //}
    }
}
