using Chinook.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Data
{
    public class ArtistDA:BaseConnection
    {
        public int GetCount()
        {
            var result = 0;

            var sql = "SELECT COUNT(1) FROM Artist";
            /*1: Create una instancia sql DbConnection*/
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                /*2: Create ua instancia de Command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); //Abriendo la conexion a la DB
                           /*3. ejecutando el comando*/
                result = (int)cmd.ExecuteScalar();
            }

            return result;
        }

        public List<Artist> GetArtists()
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                /*2: Create ua instancia de Command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); //Abriendo la conexion a la DB
                           /*3. ejecutando el comando*/

                var indice = 0;
                var reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    indice = reader.GetOrdinal("ArtistId");
                    var artistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    var name = reader.GetString(indice);

                    result.Add(
                            new Artist()
                            {
                                ArtistId = artistId,
                                Name = name
                            }
                        );
                }
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
                /*2: Create ua instancia de Command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = cn;

                //agregando el parametro

                cmd.Parameters.Add(new SqlParameter("@pNombre", filterByName));

                cn.Open(); //Abriendo la conexion a la DB
                           /*3. ejecutando el comando*/

                var indice = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    indice = reader.GetOrdinal("ArtistId");
                    var artistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    var name = reader.GetString(indice);

                    result.Add(
                            new Artist()
                            {
                                ArtistId = artistId,
                                Name = name
                            }
                        );
                }
            }

            return result;
        }


        public List<Artist> GetArtists(string filterByName)
        {
            var result = new List<Artist>();
            var sql = "SELECT ArtistId,Name FROM Artist WHERE Name like @name";
            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                /*2: Create ua instancia de Command*/
                IDbCommand cmd = new SqlCommand(sql);
                cmd.Connection = cn;
                cn.Open(); //Abriendo la conexion a la DB
                           /*3. ejecutando el comando*/

                /*Configurando los parametros*/
                cmd.Parameters.Add(new
                    SqlParameter("@name", filterByName)
                    );

                var indice = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    indice = reader.GetOrdinal("ArtistId");
                    var artistId = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("Name");
                    var name = reader.GetString(indice);

                    result.Add(
                            new Artist()
                            {
                                ArtistId = artistId,
                                Name = name
                            }
                        );
                }
            }

            return result;
        }

        public int InsertArtits(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                IDbCommand command = new SqlCommand("usp_InsertArtistX");
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));

                result = Convert.ToInt32(command.ExecuteScalar());
            }

                return result;
        }

        public int InsertArtitsWithOutPut(Artist entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                IDbCommand command = new SqlCommand("usp_InsertArtistXWithOutput");
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));

                result = Convert.ToInt32(command.ExecuteScalar());

                var parameOutID = new SqlParameter();
                parameOutID.ParameterName = "@ID";
                parameOutID.Direction = ParameterDirection.Output;
                parameOutID.DbType = DbType.Int32;

                command.ExecuteScalar();

                result = Convert.ToInt32(parameOutID.Value);
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
                //Local Tranasaction

                var transaction = cn.BeginTransaction();

                try
                {

                    IDbCommand command = new SqlCommand("usp_InsertArtistX");
                    command.Connection = cn;
                    command.Transaction = transaction;//LOCAL TRANSACTION
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Name", entity.Name));

                    result = Convert.ToInt32(command.ExecuteScalar());

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
    }
}
