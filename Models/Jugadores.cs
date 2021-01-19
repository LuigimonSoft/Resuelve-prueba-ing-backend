using System;
using System.Collections;
using System.Collections.Generic;

namespace Resuelve_prueba_ing_backend.Models
{
  /// <summary>
  /// Clase jugadores contiene los jugadores a calcular
  /// </summary>
  public class cJugadores{

    public cJugadores()
    {
      jugadores= new List<Jugador>();
    }
    public List<Jugador> jugadores {set;get;}
  }
}