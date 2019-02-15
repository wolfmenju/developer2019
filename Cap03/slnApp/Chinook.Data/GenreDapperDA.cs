using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Chinook.Entities;
using Dapper;
using System.Transactions;

namespace Chinook.Data
{
    public class GenereDapperDA:BaseConnection
    {
        public List<Genre> GetGenreWithSP(string filterByName)
        {
            var result = new List<Genre>();
            var sql = "usp_GetGenre";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<Genre>(sql, new { pNombre = filterByName }, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }

        public int InsertGenre(Genre entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>("usp_InsertArtistX", new { Name = entity.Name }, commandType: CommandType.StoredProcedure).Single();

            }

            return result;
        }

        public bool UpdateGenre(Genre entity)
        {

            var result = false;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Query("usp_UpdateGenre", new { Name = entity.Name }, commandType: CommandType.StoredProcedure);
                result = true;
            }

            return result;
        }



    }
}
