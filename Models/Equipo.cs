using System;
using System.Collections;
using System.Collections.Generic;

namespace Resuelve_prueba_ing_backend.Models
{
  /// <summary>
  /// Clase Equipo contiene la descripcion de cada equipo y sus jugadores asi como los niveles
  /// </summary>
  public class Equipo
  {
    #region  Propiedades publicas
    public string Nombre { set; get;}
    
    public List<Nivel> Niveles { set; get; }

    public List<Jugador> Jugadores { set; get;} 

    #endregion

    #region Propiedades privadas
    
    private Dictionary<string,Nivel> _Niveles { set; get; }

    private int MetaEquipo=0;
    private int TotalGolesEquipo=0;

    private double PorcentajeMetaEquipo=0;
    #endregion
    public Equipo()
    {
      _Niveles= new Dictionary<string, Nivel>();
      Jugadores= new List<Jugador>();
      Niveles= new List<Nivel>();
    }

    #region Metodos publicos

    /// <summary>
    /// Agrega un nuevo jugador a la lista de jugadores 
    /// </summary>
    /// <param name="jugadorAgregar">Jugador a agregar </param>
    /// <param name="Errores">Lista de errores </param>
    /// <returns>Retorna true si el jugador fue agregado a la lista y false en caso de existir algun error al agregarlo</returns>
    public bool AgregarJugador(Jugador jugadorAgregar, out List<string> Errores)
    {
      bool Agregado=false;
      Errores= new List<string>();
      if(_Niveles.Count>0)
      {
        if(VerificarJugador(jugadorAgregar,out Errores))
        {
          jugadorAgregar.MetaIndividual= _Niveles[jugadorAgregar.nivel].GolMes;
          jugadorAgregar.goles_minimos = jugadorAgregar.MetaIndividual;
          Jugadores.Add(jugadorAgregar);
          CalcularMetaEquipo();
          Agregado=true;
        }
      }
      else
      {
        Agregado=false;
        Errores.Add("Es necesario ingresar primero los niveles del equipo");
      }
      return Agregado;
    }

    /// <summary>
    /// Agrega un niverl a la lista de niveles del equipo
    /// </summary>
    /// <param name="nivelAgregar">nivel a agregar</param>
    /// <param name="Errores">lista de errores</param>
    /// <returns>Regresa true en caso de ser agregado el nivel y false en caso contrario</returns>
    public bool AgregarNivel(Nivel nivelAgregar, out List<string> Errores )
    {
      Errores= new List<string>();
       if(VerificarNivel(nivelAgregar, out Errores))
       {
         _Niveles.Add(nivelAgregar.nivel,nivelAgregar);
         Niveles.Add(nivelAgregar);
         return true;
       }
       else 
        return false;
    }

    /// <summary>
    /// Verifica que el equipo este correcto 
    /// </summary>
    /// <param name="Errores"> Lista de errores del equipo</param>
    /// <returns>Regresa true si el equipo es correcto en caso contrario regresa false</returns>
    public bool Verificar(out List<string> Errores)
    {
      bool Correcto=true;
      Errores= new List<string>();

      if(string.IsNullOrWhiteSpace(Nombre))
      {
        Correcto=false;
        Errores.Add("El nombre del equipo es obligatorio");
      }

      if(Niveles.Count==0)
      {
        Correcto=false;
        Errores.Add("Los niveles son obligatorios");
      }
      else
      {
        List<string> ErroresNiveles= new List<string>();
        foreach(Nivel nivel in Niveles)
        {
          if(!AgregarNivel(nivel,out ErroresNiveles))
          {
            Correcto=false;
            foreach(string errornivel in ErroresNiveles)
              Errores.Add(errornivel);
          }
        }
      }

      return Correcto;
    }

    #endregion

    #region Metodos Privados

    #region Metodos para el jugador

    /// <summary>
    /// Verifica que el jugador este correcto para poder ser ingresado
    /// </summary>
    /// <param name="jugadorVerificar">Jugador a verificar</param>
    /// <param name="Errores">Lista de errores en caso de que este incorrecto</param>
    /// <returns>Regresa true si el jugador es correcto y false en caso contrario</returns>
    private bool VerificarJugador(Jugador jugadorVerificar,out List<string> Errores)
    {
      bool Correcto=true;
      Errores= new List<string>();

      if(jugadorVerificar.Verificar(out Errores))
      {
        if(!_Niveles.ContainsKey(jugadorVerificar.nivel))
        {
          Correcto=false;
          Errores.Add("El nivel del jugador no se encontro en la lista de niveles por equipo");
        }
      }
      else 
        Correcto=false;

      return Correcto;
    }
    #endregion

    #region Calculos
    /// <summary>
    /// Metodo para calcular las metas del equipo y pasarselo a cada jugador
    /// </summary>
    private void CalcularMetaEquipo()
    {
      MetaEquipo=0;
      TotalGolesEquipo=0;
      PorcentajeMetaEquipo=0;
      foreach(Jugador jugador in Jugadores)
      {
        MetaEquipo+=_Niveles[jugador.nivel].GolMes;
        TotalGolesEquipo+= jugador.goles;
        PorcentajeMetaEquipo = (TotalGolesEquipo*100)/MetaEquipo;
      }
      foreach(Jugador jugador in Jugadores)
        jugador.PorcentajeMetaEquipo=PorcentajeMetaEquipo;
    }

    #endregion

    #region  Metodos para los niveles
    /// <summary>
    /// Verifica que el nivel a agregar este correcto
    /// </summary>
    /// <param name="nivelVerificar">Nivel a verificar</param>
    /// <param name="Errores">Errores encontrados en el nivel</param>
    /// <returns>Regresa true en caso de estar correcto el nivel o false en caso contrario </returns>
    private bool VerificarNivel(Nivel nivelVerificar,out List<string> Errores)
    {
      bool Correcto=true;
      Errores= new List<string>();

      if(nivelVerificar.Verificar(out Errores))
      {
        if(_Niveles.ContainsKey(nivelVerificar.nivel))
        {
          Correcto=false;
          Errores.Add($"El nivel {nivelVerificar.nivel} ya existe en la lista de niveles");
        }
      }
      else 
        Correcto=false;

      return Correcto;
    }
    #endregion

    #endregion 
  }
}