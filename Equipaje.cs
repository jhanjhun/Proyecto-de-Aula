public class Equipaje
    {
        public string IdEquipaje { get; set; }
        public double Peso { get; set; }
        public string IdVagonCarga { get; set; }

        public Equipaje(string idEquipaje, double peso, string idVagonCarga)
        {
            IdEquipaje = idEquipaje;
            Peso = peso;
            IdVagonCarga = idVagonCarga;
        }
    }
