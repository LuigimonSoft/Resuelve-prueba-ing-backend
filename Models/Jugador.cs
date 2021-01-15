using System;
using System.Collections;
using System.Collections.Generic;

namespace Resuelve_prueba_ing_backend
{
  public class Jugador{
    public string nombre { set; get; }

    [Newtonsoft.Json.JsonProperty(NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public string nivel { set; get; }
    public int goles { set; get; }
    public int? goles_minimos { set; get; }
    public double sueldo { set; get; }
    public double bono { set; get; }
    public double? sueldo_completo { set; get; }
    public string equipo { set; get; }
    
  }
}