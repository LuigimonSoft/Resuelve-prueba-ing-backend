import ResuelveService from './iniServices'
const Resuelve = {}

Resuelve.ObtenerEquipos = function ObtenerEquipos() {
    return ResuelveService.get('Equipos',{}).then(res => res.data).catch(err=>err)
}

Resuelve.ObtenerEquipo = function ObtenerEquipo(equipo) {
  return ResuelveService.get('Equipos',{ equipo }).then(res => res.data).catch(err=>err)
}

Resuelve.NuevoEquipo = function NuevoEquipo(equipo) {
  return ResuelveService.post('Equipos',{ equipo }).then(res => res.data).catch(err=>err)
}

export default Resuelve