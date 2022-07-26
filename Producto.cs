

namespace JorgeAlbariño
{
    public  class Producto
    {
        private int _id;
        private string _descripcion ;
        private double _costo;
        private double _precioVenta;
        private int _stock;
        private int _idUsuario;

        public Producto(int id, string descripcion, double costo, double precioVenta, int stock, 
            int idUsuario)
        {
            this._id = id;
            this._descripcion = descripcion;
            this._costo = costo;
            this._precioVenta = precioVenta;
            this._stock = stock;
            this._idUsuario = idUsuario;
        }

    }
}
