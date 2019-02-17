using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Chinook.Entities;
using Chinook.Data;
using Dapper;

namespace Chinook.Data
{
    public class AlbumDapperDA:BaseConnection
    {
        public List<Album> GetAlbumSP(string filterByName)
        {
            var result = new List<Album>();
            var sql = "usp_GetAlbum";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<Album>(sql, new { pTitle = filterByName }, commandType: CommandType.StoredProcedure).ToList();
                //result = cn.Query<Album>(sql, new { pTittle = filterByName }, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }
    }
}
