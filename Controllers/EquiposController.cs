using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Resuelve_prueba_ing_backend.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class EquiposController : Controller
  {
         /// <summary>
         /// Metodo POST para agregar un nuevo equipo 
         /// </summary>
         /// <param name="EquipoNuevo">Contiene los datos del equipo a agregar</param>
         /// <returns>Regresa un mensaje de se agrego correctamente o un error con los detalles del error al agregar</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AgregarEquipo(Models.Equipo EquipoNuevo)
        {
          List<Models.cError> Errores=new List<Models.cError>();
          if(!Startup.Equipos.ContainsKey(EquipoNuevo.Nombre))
          {
              if(EquipoNuevo.Niveles.Count>0)
              {
                List<string> ErroresEquipo = new List<string>();
                if(EquipoNuevo.Verificar(out ErroresEquipo))
                {
                  Startup.Equipos.Add(EquipoNuevo.Nombre,EquipoNuevo);
                }
                else 
                  Errores.Add(new Models.cError(){Error=$"Error al agregar el equipo {EquipoNuevo.Nombre}",Detalles = ErroresEquipo });
              }
              else 
                Errores.Add(new Models.cError(){Error=$"Error al agregar el equipo {EquipoNuevo.Nombre}",Detalles= new List<string>() {"Los niveles del equipo son obligatorios"}});
          }
          else 
          {
            Errores.Add(new Models.cError(){Error=$"Error al agregar el equipo {EquipoNuevo.Nombre}",Detalles= new List<string>() {"El equipo ya existe"}});
          }

          if(Errores.Count>0)
            return StatusCode(StatusCodes.Status400BadRequest,Errores);
          else
          {

            return StatusCode(StatusCodes.Status200OK,"{\"Resultado\": \"Se agrego el equipo " + EquipoNuevo.Nombre + " correctamente\"}");
          }


        }

        /// <summary>
        /// Obtiene un equipo segun el nombre 
        /// </summary>
        /// <param name="equipo">nombre del equipo a obtener</param>
        /// <returns>Si el equipo existe se muestra en caso contrario se responde con un 404 not found</returns>
        [HttpGet("{equipo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult MostrarEquipo(string equipo)
        {
          if(Startup.Equipos.ContainsKey(equipo.ToLower().Trim()))
            return StatusCode(StatusCodes.Status200OK,Startup.Equipos[equipo]);
          else 
            return NotFound();
        }
        
         /// <summary>
         /// Metodo get para obtener todos los equipos 
         /// </summary>
         /// <returns>Regresa la lista de equipos con sus niveles y sus jugadores</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Equipos()
        {
          List<Models.Equipo> equipos= new List<Models.Equipo>();
          foreach(KeyValuePair<string,Models.Equipo> equipo in Startup.Equipos)
            equipos.Add(equipo.Value);
          return StatusCode(StatusCodes.Status200OK,equipos);
        }

        
  }
}