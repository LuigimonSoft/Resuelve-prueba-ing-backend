using System;
using System.Collections;
using System.Collections.Generic;

namespace Resuelve_prueba_ing_backend
{
  public class Equipo
  {
    public string Nombre { set; get;}
    public Dictionary<string,Nivel> Niveles { set; get; }

    public List<Jugador> Jugadores { set; get;} 
  }
}