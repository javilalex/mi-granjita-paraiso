/*
  Archivos CSS 
  Configuracion third party
*/
import "../node_modules/bootstrap/dist/css/bootstrap-grid.min.css";
import "../node_modules/bootstrap/dist/css/bootstrap.min.css";
import "sweetalert2/dist/sweetalert2.min.css";
import "swiper/css/bundle";

//estilos personales
import "./assets/css/style.css";

//Instancia de Vue
import { createApp, h } from "vue";
import VueSweetAlert2 from "vue-sweetalert2";
import VueProgressBar from "@aacassandra/vue3-progressbar";
import "bootstrap";
import "bootstrap-icons/font/bootstrap-icons.css";

//Archivos JS personalizados
import app from "./App.vue";
import router from "./router";
import store from "./store";

//Configuraciones necesarias para la animacion de cargando
const options = {
  color: "var(--cs-pueblo)",
  failedColor: "#874b4b",
  thickness: "5px",
  transition: {
    speed: "0.2s",
    opacity: "0.6s",
    termination: 300,
  },
};

//vuejs 3.0 sintax
createApp({
  render: () => h(app),
})
  .use(store)
  .use(router)
  .use(VueSweetAlert2)
  .use(VueProgressBar, options)
  .mount("#app");
