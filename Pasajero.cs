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
    }