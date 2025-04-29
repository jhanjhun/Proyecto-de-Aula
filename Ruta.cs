public class Ruta
    {
        public string IdRuta { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public List<string> Estaciones { get; set; }

        public Ruta(string idRuta, string origen, string destino, List<string> estaciones)
        {
            IdRuta = idRuta;
            Origen = origen;
            Destino = destino;
            Estaciones = estaciones;
        }

        public string RecomendarRuta()
        {
            return $"Ruta recomendada: {Origen} -> {Destino}";
        }

        public void ModificarRuta(List<string> nuevasEstaciones)
        {
            Estaciones = nuevasEstaciones;
        }
    }