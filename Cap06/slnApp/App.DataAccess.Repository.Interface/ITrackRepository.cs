using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.EF.Entities.Query;
using App.Entities.Base;

namespace App.DataAccess.Repository.Interface
{
    public interface ITrackRepository : IGenericRepository<Track>
    { 
       IEnumerable<TrackAll> GetTrackAlls(string nombre);
    }
}
