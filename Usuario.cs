namespace JorgeAlbariño
{
    public class Usuario
    {
        private int _id;
        private string _name;
        private string _apellido;
        private string _nombreUsuario;
        private string _contraseña;
        private string _mail;

        public Usuario (int id, string name, string apellido, string nombreUsuario, string contraseña,
            string mail )
        {
            this._id = id;
            this._name = name;
            this._apellido = apellido;
            this._nombreUsuario = nombreUsuario;
            this._contraseña = contraseña;
            this._mail = mail;  

            
        }

    }
}
