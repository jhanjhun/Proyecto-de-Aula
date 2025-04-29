 public class Administrador
    {
        public List<Tren> TrenesGestionados { get; set; }

        public Administrador()
        {
            TrenesGestionados = new List<Tren>();
        }

        public bool AgregarTren(Tren tren)
        {
            if (TrenesGestionados.Any(t => t.IdTren == tren.IdTren)) return false;
            TrenesGestionados.Add(tren);
            return true;
        }

        public bool DarDeBajaTren(string idTren)
        {
            var tren = TrenesGestionados.FirstOrDefault(t => t.IdTren == idTren);
            if (tren == null) return false;
            TrenesGestionados.Remove(tren);
            return true;
        }

        public bool ModificarTarifa(Tarifa tarifa, List<Tarifa> listaTarifas)
        {
            var t = listaTarifas.FirstOrDefault(x => x.IdTarifa == tarifa.IdTarifa);
            if (t == null) return false;
            t.ValorPorKilometro = tarifa.ValorPorKilometro;
            t.CategoriaPasajero = tarifa.CategoriaPasajero;
            return true;
        }
    }
