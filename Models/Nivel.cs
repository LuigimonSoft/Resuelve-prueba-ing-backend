using System;
using System.Collections;
using System.Collections.Generic;

namespace Resuelve_prueba_ing_backend.Models
{
  /// <summary>
  ///  Clase Nivel representa un nivel de cada equipo
  /// </summary>
  public class Nivel{
    public string nivel { set; get; }
    public int GolMes { set; get; }

    #region  Metodos publicos
    /// <summary>
    /// Verifica que los datos  del nivel sean correctos
    /// </summary>
    /// <param name="Errores">Lista de errores encontrados</param>
    /// <returns>Regresa true en caso de estar correcto y false en caso contrario</returns>
    public bool Verificar(out List<string> Errores)
    {
      bool Correcto=true;
      Errores= new List<string>();

      if(string.IsNullOrWhiteSpace(nivel))
      {
        Correcto=false;
        Errores.Add("El nivel es obligatorio");
      }

      if(GolMes<0)
      {
        Correcto=false;
        Errores.Add("Los goles por mes deben ser mayores o iguales a cero");
      }

      return Correcto;
    }

    #endregion

  }
}