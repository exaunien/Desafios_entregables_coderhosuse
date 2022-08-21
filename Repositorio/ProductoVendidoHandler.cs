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
    public class ProductoVendidoHandler : DbHandler
    {
        public List<ProductoVendido> Listar()
        {
            List<ProductoVendido> list = new List<ProductoVendido>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(CadenaConn))
                {
                    string queryCommand = "SELECT pd.Descripciones, pv.Stock, pv.IdVenta FROM Producto pd INNER JOIN ProductoVendido pv ON pd.Id=pv.IdProducto";

                    using (SqlCommand sqlCom = new SqlCommand(queryCommand, conexion))
                    {
                        conexion.Open();

                        using (SqlDataReader reader = sqlCom.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    ProductoVendido productoVendido = new ProductoVendido();
                                    productoVendido.Descripciones = (reader["Descripciones"]).ToString();
                                    productoVendido._Stock = Convert.ToInt32(reader["stock"]);
                                    list.Add(productoVendido);
                                }
                                foreach (ProductoVendido productoVendido in list)
                                {
                                    string descripcion = productoVendido.Descripciones.ToString();
                                    string existencia = productoVendido._Stock.ToString();
                                    Console.WriteLine("Producto : {0}  " + "  stock : {1}  ", descripcion, existencia);

                                }
                            }
                        }
                        conexion.Close();
                    }
                }

            }
            catch (Exception e)
            {

                Console.WriteLine("{0} error ", e);
            }
           
            return list;
        }

        public void Agregar()
        {
            try
            {


            }
            catch (Exception e)
            {

                Console.WriteLine("{0} Error", e);
            }
        }
    }
}

