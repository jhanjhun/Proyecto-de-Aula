public class Tarifa
    {
        public string IdTarifa { get; set; }
        public double ValorPorKilometro { get; set; }
        public string CategoriaPasajero { get; set; }

        public Tarifa(string idTarifa, double valorPorKilometro, string categoriaPasajero)
        {
            IdTarifa = idTarifa;
            ValorPorKilometro = valorPorKilometro;
            CategoriaPasajero = categoriaPasajero;
        }
    }