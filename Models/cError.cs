using System;
using System.Collections;
using System.Collections.Generic;

namespace Resuelve_prueba_ing_backend.Models
{
  /// <summary>
  /// Clase Error contiene el error y la descripcion de cada error 
  /// </summary>
  public class cError
  {
    public cError()
    {
      Detalles= new List<string>();
    }
    public string Error{set; get;}
    public List<string> Detalles{ set; get; }
  }
}