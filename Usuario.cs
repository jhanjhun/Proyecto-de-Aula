public class Usuario
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public Usuario(string id, string nombre, string apellido, string tipoIdentificacion, string direccion, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            TipoIdentificacion = tipoIdentificacion;
            Direccion = direccion;
            Telefono = telefono;
        }

        public bool IniciarSesion(string usuario, string contrasena)
        {
            // Lógica simple de inicio de sesión (dummy)
            return Nombre == usuario;
        }
    }