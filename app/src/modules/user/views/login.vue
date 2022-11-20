<template>
  <div class="sm-container">
    <div class="card shadow">
      <div class="card-body">
        <form class="row gy-4" @submit.prevent="onSubmit" novalidate>
          <h1>Bienvenido</h1>
          <div class="col-12 text-start">
            <label for="usuario">Usuario</label>
            <input
              class="form-control"
              type="text"
              v-model="usuario"
              required
              id="usuario"
            />
            <span class="invalid-feedback text-start"
              >Por favor ingresa tu usuario</span
            >
          </div>
          <div class="col-12 text-start">
            <label for="contraseña">Contraseña</label>
            <input
              class="form-control"
              type="text"
              v-model="contraseña"
              required
              id="contraseña"
            />
            <span class="invalid-feedback text-start"
              >Por favor ingresa la contraseña</span
            >
          </div>
          <div class="col-12">
            <input
              class="form-check-input me-2"
              type="checkbox"
              v-model="recordarNavegador"
              id="recordarNavegador"
            />
            <label class="form-check-label" for="recordarNavegador"
              >Recordar dispositivo</label
            >
          </div>
          <div class="col-12">
            <button class="btn btn-primary">Iniciar Sesion</button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>
<script>
import api from "@/config/api.js";

export default {
  name: "loginView",
  data() {
    return {
      usuario: null,
      contraseña: null,
      recordarNavegador: null,
      isLoading: false,
    };
  },
  methods: {
    onSubmit({ target }) {
      if (this.isLoading) return;
      const { data } = api.get("/ping");

      console.log(data);
      if (target.checkValidity()) {
        //ToDo
      } else {
        target.classList.add("was-validated");
      }
    },
  },
};
</script>
<style scoped>
.sm-container {
  max-width: 400px;
  margin: auto;
}
</style>
