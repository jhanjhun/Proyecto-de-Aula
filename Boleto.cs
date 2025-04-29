public class Boleto
    {
        public string IdBoleto { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public string IdPasajero { get; set; }
        public string IdTren { get; set; }
        public string Lugar { get; set; }
        public string CategoriaPasajero { get; set; }
        public double ValorPasaje { get; set; }
        public string Equipaje { get; set; }

        public Boleto(string idBoleto, DateTime fechaSalida, DateTime fechaLlegada,
                      string idPasajero, string idTren, string lugar, string categoriaPasajero,
                      double valorPasaje, string equipaje)
        {
            IdBoleto = idBoleto;
            FechaCompra = DateTime.Now;
            FechaSalida = fechaSalida;
            FechaLlegada = fechaLlegada;
            IdPasajero = idPasajero;
            IdTren = idTren;
            Lugar = lugar;
            CategoriaPasajero = categoriaPasajero;
            ValorPasaje = valorPasaje;
            Equipaje = equipaje;
        }

        public string GenerarConfirmacion()
        {
            return $"Boleto {IdBoleto}: Pasajero {IdPasajero}, Tren {IdTren}, " +
                   $"Salida {FechaSalida}, Llegada {FechaLlegada}, Valor {ValorPasaje}";
        }
    }