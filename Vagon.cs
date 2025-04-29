public enum TipoVagon { Pasajeros, Carga }

    public class Vagon
    {
        public string IdVagon { get; set; }
        public TipoVagon Tipo { get; set; }
        public int Capacidad { get; set; }
        public int LugaresPremium { get; set; }
        public int LugaresEjecutivo { get; set; }
        public int LugaresEstandar { get; set; }
        public List<Usuario> PasajerosAsignados { get; set; }

        public Vagon(string idVagon, TipoVagon tipo, int lugaresPremium, int lugaresEjecutivo, int lugaresEstandar)
        {
            IdVagon = idVagon;
            Tipo = tipo;
            LugaresPremium = lugaresPremium;
            LugaresEjecutivo = lugaresEjecutivo;
            LugaresEstandar = lugaresEstandar;
            Capacidad = tipo == TipoVagon.Pasajeros
                ? lugaresPremium + lugaresEjecutivo + lugaresEstandar
                : 0;
            PasajerosAsignados = new List<Usuario>();
        }

        public bool AsignarLugar(Usuario pasajero)
        {
            if (Tipo != TipoVagon.Pasajeros || PasajerosAsignados.Count >= Capacidad)
                return false;
            PasajerosAsignados.Add(pasajero);
            return true;
        }
    }