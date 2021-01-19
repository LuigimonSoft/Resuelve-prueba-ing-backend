using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Resuelve_prueba_ing_backend.Controllers
{
  [Route("Jugadores")]
  [ApiController]
  public class JugadoresController : ControllerBase
  {
    [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult ProcesarJugadores(Models.cJugadores jugadoresCalcular)
        {
          List<Models.cError> Errores=new List<Models.cError>();
          foreach (Models.Jugador jugador in jugadoresCalcular.jugadores)
          {
            List<string> ErroresJugador=new List<string>();
            if(Startup.Equipos.ContainsKey(jugador.equipo.ToLower().Trim()))
            {
              if(!Startup.Equipos[jugador.equipo.ToLower().Trim()].AgregarJugador(jugador,out ErroresJugador))
                Errores.Add(new Models.cError(){ Error= $"Error al guardar el jugador {jugador.nombre}", Detalles= ErroresJugador});
            }
            else 
            {
              Errores.Add(new Models.cError(){ Error= $"Error al guardar el jugador {jugador.nombre}", Detalles= new List<string>(){$"no se encontro el equipo {jugador.equipo}"}});
            }
          }

          if(Errores.Count>0)
            return StatusCode(StatusCodes.Status400BadRequest,Errores);
          else
          {
            Models.cJugadores ResultadoJugadores= new Models.cJugadores();
            foreach(KeyValuePair<string, Models.Equipo> equipo in Startup.Equipos.ToList())
            {
              foreach(Models.Jugador jugador in equipo.Value.Jugadores)
                ResultadoJugadores.jugadores.Add(jugador);
            }

            return StatusCode(StatusCodes.Status200OK,ResultadoJugadores);
          }

        }
  }
}