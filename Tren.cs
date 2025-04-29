public class Tren
{
     public string IdTren { get; set; }
    public string Nombre { get; set; }
    public int CapacidadCarga { get; set; }
    public int Kilometraje { get; set; }
    public List<Vagon> Vagones { get; set; }

    public Tren(string idTren, string nombre, int capacidadCarga, int kilometraje)
    {
        IdTren = idTren;
        Nombre = nombre;
        CapacidadCarga = capacidadCarga;
        Kilometraje = kilometraje;
        Vagones = new List<Vagon>();
    }

     public bool AgregarVagon(Vagon vagon)
 {
     if (Vagones.Count < CapacidadMaximaVagones)
     {
         Vagones.Add(vagon);
         return true;
     }
     return false;
 }
    public bool EliminarVagon(string idVagon)
{
    var v = Vagones.Find(vg => vg.Identificador == idVagon);
    if (v != null)
    {
        Vagones.Remove(v);
        return true;
    }
    return false;
}
    public int CapacidadTotalPasajeros()
{
    int total = 0;
    foreach (var vagon in Vagones)
    {
        total += vagon.CapacidadPasajeros;
    }
    return total;
}
}