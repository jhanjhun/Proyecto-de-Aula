/*
public class Pasajero
    {
        public string CategoriaPasajero { get; set; }
        public string PersonaContacto { get; set; }
        public string TelefonoContacto { get; set; }
        public List<Boleto> BoletosComprados { get; set; }

        public Pasajero(string categoriaPasajero, string personaContacto, string telefonoContacto)
        {
            CategoriaPasajero = categoriaPasajero;
            PersonaContacto = personaContacto;
            TelefonoContacto = telefonoContacto;
            BoletosComprados = new List<Boleto>();
        }

        public bool ComprarBoleto(Boleto boleto)
        {
            BoletosComprados.Add(boleto);
            return true;
        }
    }/*/

    public class Pasajero
    {
        public string CategoriaPasajero { get; set; }
        public string PersonaContacto { get; set; }
        public string TelefonoContacto { get; set; }
        private class NodoBoleto
        {
            public Boleto Valor;
            public NodoBoleto Siguiente;
            public NodoBoleto Anterior;
            public NodoBoleto(Boleto b) { Valor = b; }
        }

        private NodoBoleto cabeza;
        private NodoBoleto cola;
        private int conteoBoletos;

        public Pasajero(string categoriaPasajero, string personaContacto, string telefonoContacto)
        {
            CategoriaPasajero = categoriaPasajero;
            PersonaContacto = personaContacto;
            TelefonoContacto = telefonoContacto;
            cabeza = cola = null;
            conteoBoletos = 0;
        }
        public bool ComprarBoleto(Boleto boleto)
        {
            if (boleto == null)
                return false;

            var nodo = new NodoBoleto(boleto);
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
            conteoBoletos++;
            return true;
        }
¿        public bool CancelarBoleto(string idBoleto)
        {
            var actual = cabeza;
            while (actual != null)
            {
                if (actual.Valor.IdBoleto == idBoleto)
                {
                    if (actual.Anterior != null)
                        actual.Anterior.Siguiente = actual.Siguiente;
                    else
                        cabeza = actual.Siguiente;

                    if (actual.Siguiente != null)
                        actual.Siguiente.Anterior = actual.Anterior;
                    else
                        cola = actual.Anterior;

                    conteoBoletos--;
                    return true;
                }
                actual = actual.Siguiente;
            }
            return false;
        }
     public IEnumerable<Boleto> ObtenerBoletos()
        {
            var actual = cabeza;
            while (actual != null)
            {
                yield return actual.Valor;
                actual = actual.Siguiente;
            }
        }
    }