import { createWebHistory, createRouter } from "vue-router";

import defaultLayout from "@/layouts/default-layout.vue";

import userRoutes from "@/modules/user/router/";

const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: "/",
      name: "inicio",
      props: true,
      component: () =>
        import(/* webpackChunkName: "inicio" */ "../views/inicio.vue"),
      meta: {
        layout: defaultLayout,
      },
    },
    {
      path: "/galeria/:img?",
      name: "Galeria",
      component: () =>
        import(/* webpackChunkName: "galeria" */ "../views/galeria.vue"),
      meta: {
        layout: defaultLayout,
      },
    },
    {
      path: "/consejos",
      name: "Consejos",
      props: true,
      component: () =>
        import(/* webpackChunkName: "consejos" */ "../views/consejos.vue"),
      meta: {
        layout: defaultLayout,
      },
    },
    {
      path: "/contacto",
      name: "Contacto",
      props: true,
      component: () =>
        import(/* webpackChunkName: "contacto" */ "../views/contacto.vue"),
      meta: {
        layout: defaultLayout,
      },
    },
    {
      path: "/:source/:type/:item",
      name: "VistaElemento",
      props: true,
      component: () =>
        import(
          /* webpackChunkName: "vista-elemento" */ "../views/vista-elemento.vue"
        ),
      meta: {
        layout: defaultLayout,
      },
    },
    {
      path: "/:pathMatch(.*)*",
      name: "Pagina no encontrada",
      component: () =>
        import(
          /* webpackChunkName: "pagina-no-encontrada" */ "../views/pagina-no-encontrada.vue"
        ),
      meta: {
        layout: defaultLayout,
      },
    },
    {
      path: "/admin",
      name: "Administrar sitio",
      children: [...userRoutes],
    },
  ],
});

router.afterEach((to /*from*/) => {
  document.title =
    to.name == "inicio"
      ? "Mi Granjita Paraiso"
      : `Mi Granjita Paraiso - ${to.name}`;
});

export default router;
