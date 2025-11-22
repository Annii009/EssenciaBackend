using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Models;
public class Mesas
{
    public int MesasId { get; set; }
    public int NumeroMesa { get; set; }
    public int Capacidad {get; set;}
    public bool Disponible {get; set;}
    public string Ubicacion {get; set;}


}


