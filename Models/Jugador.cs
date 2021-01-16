using System;
using System.Collections;
using System.Collections.Generic;

namespace Resuelve_prueba_ing_backend
{
  /// <summary>
  /// Clase jugador contiene la descripcion de cada jugador 
  /// </summary>
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

    [Newtonsoft.Json.JsonProperty(NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public int MetaIndividual{ 
      set{
        _MetaIndividual=value;
        _porcentajeMetaIndividual = (goles*100)/_MetaIndividual;
        if(_PorcentajeMetaEquipo>-1)
        {
          _promedioMetas=(PorcentajeMetaEquipo + _porcentajeMetaIndividual)/2;
          sueldo_completo = sueldo+(bono*(_promedioMetas/100));
        }
      } 
      get{
        return _MetaIndividual;
      }
    }

    [Newtonsoft.Json.JsonProperty(NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
    public double PorcentajeMetaEquipo{
      set{
        _PorcentajeMetaEquipo=value;
        if(_porcentajeMetaIndividual>-1)
        {
          _promedioMetas=(PorcentajeMetaEquipo + _porcentajeMetaIndividual)/2;
          sueldo_completo = sueldo+(bono*(_promedioMetas/100));
        }
      }
      get{
        return _PorcentajeMetaEquipo;
      }
      }
    
    #region Metodos privados

    private int _MetaIndividual = 0;
    private double _porcentajeMetaIndividual = -1;
    private double _PorcentajeMetaEquipo=-1;

    private double _promedioMetas = 0;

    #endregion

    #region  Metodos publicos
    /// <summary>
    /// Verifica que los datos del jugador sean ingresados correctamente
    /// </summary>
    /// <param name="Errores">Lista de errores</param>
    /// <returns>Regresa true en caso de estar correcto y false en caso de tener errores</returns>
    public bool Verificar(out List<string> Errores)
    {
      bool Correcto=true;
      Errores= new List<string>();

      if(string.IsNullOrWhiteSpace(nombre))
      {
        Correcto=false;
        Errores.Add("El nombre del jugador es obligatorio");
      }
      
      if(string.IsNullOrWhiteSpace(equipo))
      {
        Correcto=false;
        Errores.Add("El equipo del jugador es obligatorio");
      }

      if(string.IsNullOrWhiteSpace(nivel))
      {
        Correcto=false;
        Errores.Add("El nivel del jugador es obligatorio");
      }

      if(bono<0)
      {
        Correcto=false;
        Errores.Add("El bono del jugador debe ser mayor o igual a cero");
      }

      if(sueldo<=0)
      {
        Correcto=false;
        Errores.Add("El sueldo del jugador debe ser mayor a cero");
      }

      if(goles<0) // No se dijo nada en caso de que el jugador hiciera un autogol
      {
        Correcto=false;
        Errores.Add("Los goles del jugador deben ser mayor o  igual a cero");
      }

      return Correcto;
    }
    #endregion
  }
}