public class Empleado
    {
        public Boleto ConsultarBoleto(string idBoleto, List<Boleto> listaBoletos)
        {
            return listaBoletos.FirstOrDefault(b => b.IdBoleto == idBoleto);
        }

        public bool ModificarBoleto(Boleto boleto, List<Boleto> listaBoletos)
        {
            var b = ConsultarBoleto(boleto.IdBoleto, listaBoletos);
            if (b == null) return false;
            b.FechaSalida = boleto.FechaSalida;
            b.FechaLlegada = boleto.FechaLlegada;
            b.Lugar = boleto.Lugar;
            b.CategoriaPasajero = boleto.CategoriaPasajero;
            b.ValorPasaje = boleto.ValorPasaje;
            b.Equipaje = boleto.Equipaje;
            return true;
        }
    }