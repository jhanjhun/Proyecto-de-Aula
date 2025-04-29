public class Vagon
    {
        public string IdVagon { get; set; }
        public TipoVagon Tipo { get; set; }
        public int Capacidad { get; set; }
        public int LugaresPremium { get; set; }
        public int LugaresEjecutivo { get; set; }
        public int LugaresEstandar { get; set; }
        private class NodoPasajero
        {
            public Pasajero Valor;
            public NodoPasajero Siguiente;
            public NodoPasajero(Pasajero p) { Valor = p; }
        }
        private NodoPasajero frentePremium, finPremium;
        private NodoPasajero frenteEjecutivo, finEjecutivo;
        private NodoPasajero frenteEstandar, finEstandar;

        public Vagon(string idVagon, TipoVagon tipo, int lugaresPremium, int lugaresEjecutivo, int lugaresEstandar)
        {
            IdVagon = idVagon;
            Tipo = tipo;
            LugaresPremium = lugaresPremium;
            LugaresEjecutivo = lugaresEjecutivo;
            LugaresEstandar = lugaresEstandar;
            Capacidad = (tipo == TipoVagon.Pasajeros)
                ? lugaresPremium + lugaresEjecutivo + lugaresEstandar
                : 0;
            frentePremium = finPremium = null;
            frenteEjecutivo = finEjecutivo = null;
            frenteEstandar = finEstandar = null;
        }

        // Encola el pasajero en la cola correspondiente
        public bool AsignarLugar(Pasajero pasajero)
        {
            if (Tipo != TipoVagon.Pasajeros)
                return false;
            int total = 0;
            var tmp = frentePremium;
            while (tmp != null) { 
                total++; 
                tmp = tmp.Siguiente; 
                }
            tmp = frenteEjecutivo;
            while (tmp != null) {
                total++; 
                tmp = tmp.Siguiente; 
                }
            tmp = frenteEstandar;
            while (tmp != null) { 
                total++; 
                tmp = tmp.Siguiente; 
                }
            if (total >= Capacidad) return false;

            var nodo = new NodoPasajero(pasajero);
            switch (pasajero.CategoriaPasajero)
            {
                case "Premium":
                    if (finPremium == null) frentePremium = finPremium = nodo;
                    else finPremium = finPremium.Siguiente = nodo;
                    break;
                case "Ejecutivo":
                    if (finEjecutivo == null) frenteEjecutivo = finEjecutivo = nodo;
                    else finEjecutivo = finEjecutivo.Siguiente = nodo;
                    break;
                default:
                    if (finEstandar == null) frenteEstandar = finEstandar = nodo;
                    else finEstandar = finEstandar.Siguiente = nodo;
                    break;
            }
            return true;
        }
        // Desencolar según prioridad: Premium -> Ejecutivo -> Estándar
        public Pasajero ObtenerSiguientePasajero()
        {
            if (frentePremium != null)
            {
                var p = frentePremium.Valor;
                frentePremium = frentePremium.Siguiente;
                if (frentePremium == null) finPremium = null;
                return p;
            }
            if (frenteEjecutivo != null)
            {
                var p = frenteEjecutivo.Valor;
                frenteEjecutivo = frenteEjecutivo.Siguiente;
                if (frenteEjecutivo == null) finEjecutivo = null;
                return p;
            }
            if (frenteEstandar != null)
            {
                var p = frenteEstandar.Valor;
                frenteEstandar = frenteEstandar.Siguiente;
                if (frenteEstandar == null) finEstandar = null;
                return p;
            }
            return null;
        }
    }