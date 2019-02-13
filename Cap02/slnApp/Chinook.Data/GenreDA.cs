using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Chinook.Entities;

namespace Chinook.Data
{
    public class GenreDA:BaseConnection
    {
        public List<Artist> GetGenreWithSP(string filterByName)
        {
            var result = new List<Artist>();
            var sql = "usp_GetGenre";
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
                    indice = reader.GetOrdinal("GenreId");
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

        public int InsertGenre(Genre entity)
        {
            var result = 0;

            using (IDbConnection cn = new SqlConnection(GetConnection()))
            {
                cn.Open();
                IDbCommand command = new SqlCommand("usp_InsertGenreX");
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));

                result = Convert.ToInt32(command.ExecuteScalar());
            }

            return result;
        }
    }
}
