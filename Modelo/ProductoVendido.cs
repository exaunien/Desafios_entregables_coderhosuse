using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JorgeAlbariño.Modelo
{
    public class ProductoVendido : Producto
    {
        public int _Id { get; set; }
        public int _Stock { get; set; }
        public int _IdProducto { get; set; }
        public int _IdVenta { get; set; }

    }
}
