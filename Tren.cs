public class Tren
    {
        public string IdTren { get; set; }
        public string Nombre { get; set; }
        public int Capacidad { get; set; }
        public int Kilometraje { get; set; }

        private class NodoVagon
        {
            public Vagon Valor;
            public NodoVagon Siguiente;
            public NodoVagon Anterior;
            public NodoVagon(Vagon v) { Valor = v; }
        }

        private NodoVagon cabeza;
        private NodoVagon cola;
        private int conteoVagones;

        public Tren(string idTren, string nombre, int capacidad, int kilometraje)
        {
            IdTren = idTren;
            Nombre = nombre;
            Capacidad = capacidad;
            Kilometraje = kilometraje;
            cabeza = cola = null;
            conteoVagones = 0;
        }

     public bool AgregarVagon(Vagon vagon)
        {
            if (conteoVagones >= Capacidad)
                return false;

            var nodo = new NodoVagon(vagon);
            if (cabeza == null)
            {
                cabeza = cola = nodo;
            }
            else
            {
                cola.Siguiente = nodo;
                nodo.Anterior = cola;
                cola = nodo;
            }
            conteoVagones++;
            return true;
        }
        
        public bool EliminarVagon(string idVagon)
        {
            var actual = cabeza;
            while (actual != null)
            {
                if (actual.Valor.IdVagon == idVagon)
                {
                    if (actual.Anterior != null)
                        actual.Anterior.Siguiente = actual.Siguiente;
                    else
                        cabeza = actual.Siguiente;

                    if (actual.Siguiente != null)
                        actual.Siguiente.Anterior = actual.Anterior;
                    else
                        cola = actual.Anterior;

                    conteoVagones--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }
        public int CalcularVagonesNecesarios()
        {
            int cuentaPasajeros = 0;
            var actual = cabeza;
            while (actual != null)
            {
                if (actual.Valor.Tipo == TipoVagon.Pasajeros)
                    cuentaPasajeros++;
                actual = actual.Siguiente;
            }
            return (cuentaPasajeros + 1) / 2;
        }
}