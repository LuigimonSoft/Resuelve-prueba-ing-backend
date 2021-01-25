<template>
  <div id="app">
    <b-container style="margin-top:20px;">
      <b-row>
        <b-col>
          <h1>Equipos</h1>
        </b-col>
        <b-col>
            <b-button variant="success" @click="ObtenerEquipos()">Actualizar</b-button>
        </b-col>
      </b-row>
      <b-card v-for="equipo in Equipos" :title="equipo.nombre" class="md-6"  :key="equipo.nombre">
        <h5>Niveles</h5>
        <b-table striped hover :items="equipo.niveles"></b-table>
        <h5>Jugadores</h5>
        <b-table striped hover :items="equipo.jugadores"></b-table>
      </b-card>
      
    </b-container>
  </div>
</template>
<script>
import Resuelve from './Services/Resuelve'
export default {
  data: function() {
    return {
      Equipos:[]
    }
    },
    mounted() {
      this.ObtenerEquipos();
    },
    methods:{
      ObtenerEquipos(){
        Resuelve.ObtenerEquipos().then(datos=>this.Equipos=datos);
      }
    }
}
</script>