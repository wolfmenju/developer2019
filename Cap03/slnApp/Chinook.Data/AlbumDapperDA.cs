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
    public class AlbumDapperDA : BaseConnection
    {
        //ok
        public int GetAlbumCountDapper()
        {
            var result = 0;
            var sql = "select count(1) from Album";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>(sql).First();

            }

            return result;
        }


        public List<Album> GetAlbumSP(string filterByName)
        {
            var result = new List<Album>();
            var sql = "usp_GetAlbumSp";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<Album>(sql, new { pTitle = filterByName }, commandType: CommandType.StoredProcedure).ToList();
                //result = cn.Query<Album>(sql, new { pTittle = filterByName }, commandType: CommandType.StoredProcedure).ToList();
            }

            return result;
        }

        public int InsertAlbum(Album entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>("usp_InsertAlbumSP", new { Title = entity.Title, ArtistId = entity.ArtistId }, commandType: CommandType.StoredProcedure).Single();
            }

            return result;
        }



        public bool UpdateAlbum(Album entity)
        {

            var result = false;
           // var param = new DynamicParameters();
            //param.Add("Title", entity.Title);
            //param.Add("AlbumId", dbType: DbType.Int32, direction: ParameterDirection.Input);

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Query("usp_UpdateAlbum", new { Title=entity.Title, AlbumId=entity.AlbumId}, commandType: CommandType.StoredProcedure);
                result = true;
            }

            return result;

        }

        public int DeleteAlbumSP(Album entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<int>("usp_DeleteAlbumSP", new { AlbumId = entity.AlbumId }, commandType: CommandType.StoredProcedure).Single();
            }

            return result;
        }
    }
}
