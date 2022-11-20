<template>
  <div class="d-flex flex-column flex-grow-1 picture-background">
    <div class="container m-auto">
      <div class="card shadow my-3 bg-white-blue bac">
        <div class="card-body">
          <transition name="slide-fade-start" appear>
            <div class="row gy-3">
              <div class="col-lg-8">
                <h2 class="text-center">Necesitas ponerte en contacto</h2>
                <form @submit.prevent="sendForm" novalidate>
                  <div class="row gy-3 text-start">
                    <div class="form-group col-md-4">
                      <label for="formContactoNombre">Nombre</label>
                      <input
                        class="form-control"
                        type="text"
                        id="formContactoNombre"
                        required
                      />
                      <div class="invalid-feedback">Escribe tu nombre</div>
                    </div>
                    <div class="form-group col-md-4">
                      <label for="formContactoApellido">Apellido</label>
                      <input
                        class="form-control"
                        type="text"
                        id="formContactoApellido"
                        required
                      />
                      <div class="invalid-feedback">Escribe tu apellido</div>
                    </div>
                    <div class="form-group col-md-4">
                      <label for="formContactoTelefono">Teléfono</label>
                      <input
                        class="form-control"
                        type="text"
                        id="formContactoTelefono"
                        required
                      />
                    </div>
                    <div class="col-12">
                      <label for="formContactoMensaje">Mensaje</label>
                      <textarea
                        class="form-control"
                        rows="4"
                        id="formContactoMensaje"
                        required
                      ></textarea>
                      <div class="invalid-feedback">Escribe un mensaje</div>
                    </div>
                    <div class="col-12 d-flex">
                      <button
                        class="btn btn-outline-danger ms-auto"
                        type="reset"
                      >
                        Cancelar
                      </button>
                      <button
                        class="btn btn-outline-success ms-3"
                        type="submit"
                      >
                        Enviar
                      </button>
                    </div>
                  </div>
                </form>
              </div>
              <div class="col-lg-4">
                <h2 class="mb-3">Canales alternativos</h2>
                <div class="row gy-3">
                  <div
                    class="col-12"
                    v-for="prop in comunication"
                    :key="prop.class"
                  >
                    <a
                      :href="prop.link"
                      :class="prop.class"
                      target="_blank"
                      class="d-block mx-auto text-decoration-none mb-1"
                    ></a>
                    <a
                      :href="prop.link"
                      class="text-decoration-none text-muted"
                      target="_blank"
                      >{{ prop.message }}</a
                    >
                  </div>
                </div>
              </div>
            </div>
          </transition>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
// import Axios from 'axios';

export default {
  name: "pagina-contacto",
  props: {
    comunication: {
      type: Array,
    },
  },
  computed: {},
  data() {
    return {};
  },
  methods: {
    sendForm({ target }) {
      let self = this;

      if (target.checkValidity()) {
        self.$swal
          .fire({
            title: "Deseas Continuar?",
            text: "Seras redirigido a whatsapp",
            icon: "info",
            confirmButtonText: "Si",
            showCancelButton: true,
            cancelButtonText: "no",
          })
          .then((result) => {
            if (result.isConfirmed) {
              window.open(
                "https://wa.me/523221550227?text=test",
                null,
                "_blank"
              );
              // Axios({
              //   method:'GET',
              //   url:'https://wa.me/523221550227?text=test',
              //   headers: {
              //     "Access-Control-Allow-Origin": "*"
              //   }
              // }).then(x => console.log(x)).catch(x => console.log(x));
            } else {
              console.log("Cancel");
            }
          });
      } else {
        target.classList.add("was-validated");
      }
    },
  },
  mounted() {},
};
</script>
<style scoped>
.facebook,
.whatsapp,
.phone,
.email {
  transition: all 0.5s ease;
}

.facebook:hover,
.whatsapp:hover,
.phone:hover,
.email:hover {
  width: 50px;
  height: 50px;
}
</style>
