using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using JorgeAlbariño.Modelo;


namespace JorgeAlbariño.Repositorio
{
    public class ProductoHandler : DbHandler
    {
        public List<Producto> Listar ()
        {
            List<Producto> list = new List<Producto>();
           
            string queryCommand = "SELECT * FROM Producto AS pd INNER JOIN Usuario AS us on pd.IdUsuario = us.Id";

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
                                Producto producto = new Producto();
                                producto.Id=Convert.ToInt32(reader["Id"]);
                                producto.Stock = Convert.ToInt32(reader["Stock"]);
                                producto.IdUsuario =Convert.ToInt32(reader["IdUsuario"]);
                                producto.Costo = Convert.ToInt32(reader["Costo"]);
                                producto.PrecioVenta = Convert.ToInt32(reader["PrecioVenta"]);
                                producto.Descripciones = (reader["Descripciones"]).ToString();
                                producto._NombreUsuario = (reader["NombreUsuario"].ToString());
                                list.Add(producto);

                            }
                            var titulo = String.Format("{0,-2}{1,8}{2,10}{3,15}{4,30}{5,14}\n",
                              "Id", "Stock", "Costo", "PrecioVenta","Descripcion", "Usuario" );
                            Console.WriteLine(titulo);
                            foreach (var item in list)
                            {
                                var valor = String.Format("{0,-2}{1,8}{2,10}{3,15}{4,30}{5,14}\n",
                              item.Id, item.Stock, item.Costo, item.PrecioVenta, item.Descripciones, item._NombreUsuario);
                                Console.WriteLine(valor);

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
