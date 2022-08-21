using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JorgeAlbariño.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace JorgeAlbariño.Repositorio
{
    public class UsuarioHandler : DbHandler
    {
        public List<Usuario> Listar()
        {
            List<Usuario> list = new List<Usuario>();

            string queryCommand = "SELECT * FROM Usuario";

            using (SqlConnection conexion = new SqlConnection(CadenaConn))
            {
                using (SqlCommand sqlCom = new SqlCommand(queryCommand, conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = sqlCom.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario._Id = Convert.ToInt32(reader["Id"]);
                                usuario._Nombre = reader["Nombre"].ToString();
                                usuario._Apellido = reader["Apellido"].ToString();
                                usuario._NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario._Contraseña = reader["Contraseña"].ToString();
                                usuario._Mail = (reader["Mail"]).ToString();
                                list.Add(usuario);

                            }
                        }
                    }
                    conexion.Close();

                }
            }
            return list;
        }
    }
}

