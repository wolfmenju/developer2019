using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Dapper;
namespace Chinook.Data
{
    public class ArtistDapperDA : BaseConnection
    {
        public int GetCountDapper()
        {
            var result = 0;

            var sql = "SELECT COUNT(1) FROM Artist";
            /*1: Create una instancia sql DbConnection*/
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result=cn.Query<int>(sql).First();
   
                
            }

            return result;
        }

        public List<Artist> GetArtists()
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result=cn.Query<Artist>(sql).ToList();
                
            }

            return result;
        }


        //store procedure listar

        public List<Artist> GetArtistsWithSP(string filterByName)
        {
            var result = new List<Artist>();
            var sql = "usp_GEtArtist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result=cn.Query<Artist>(sql, new { pNombre = filterByName },commandType:CommandType.StoredProcedure).ToList();
            }

            return result;
        }


        public List<Artist> GetArtists(string filterByName)
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist WHERE Name like @name";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result = cn.Query<Artist>(sql, new { name = filterByName }, commandType: CommandType.StoredProcedure).ToList();

            }

            return result;
        }

        public int InsertArtits(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                result=cn.Query<int>("usp_InsertArtistX", new { Name = entity.Name }, commandType: CommandType.StoredProcedure).Single();

               
            }

                return result;
        }

        public int InsertArtitsWithOutPut(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                var param = new DynamicParameters();
                param.Add("Name",entity.Name);
                param.Add("ID", dbType: DbType.Int32, direction: ParameterDirection.Output);

                cn.Query("usp_InsertArtistXWithOutput",param, commandType: CommandType.StoredProcedure);

                result = param.Get<int>("ID");
            }

            return result;
        }

        //
        public int InsertArtitsWithTX(Artist entity)
        {
         
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                var tx = cn.BeginTransaction();

                try
                {
                    result = cn.Query<int>("usp_InsertArtistX", new { Name = entity.Name }, commandType: CommandType.StoredProcedure,
                    transaction: tx).Single();
                
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();

                }

               
            }

            return result;


 
        }
        //update
        public int UpdateArtitsWithTX(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                //Local Tranasaction

                var transaction = cn.BeginTransaction();

                try
                {

                    IDbCommand command = new SqlCommand("usp_UpdateArtistX");
                    command.Connection = cn;
                    command.Transaction = transaction;//LOCAL TRANSACTION
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Name", entity.Name));

                    result = Convert.ToInt32(command.ExecuteScalar());

                    //throw new Exception("Error al insertar")

                    //Confirmando la transaction local
                    transaction.Commit();

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    result = 0;
                }

            }

            return result;
        }

        //distribu
        public int InsertArtitsWithTXDsitr(Artist entity)
        {
            var result = 0;

            using (var tx = new TransactionScope())
            {

                try
                {
                    using (IDbConnection cn = new SqlConnection(GetConnection()))
                    {


                        result = cn.Query<int>("usp_InsertArtistX", new { Name = entity.Name }, commandType: CommandType.StoredProcedure).Single();                    

                    }

                    tx.Complete();
                }

                catch (Exception ex)
                {
                   
                }


            }

            return result;

        }

        public bool UpdateArtist(Artist entity)
        {

            var result = false;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Query("usp_UpdateArtist", new { Name = entity.Name }, commandType: CommandType.StoredProcedure);
                result = true;
            }

            return result;
        }
    }
}
