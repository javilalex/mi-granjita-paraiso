<template>
  <header class="fixed-top" :class="CNavBar.class">
    <div class="navbar navbar-expand-lg h-100" id="nav">
      <div class="container h-100 position-relative">
        <div
          class="d-flex col-12 col-lg-auto justify-content-between align-self-start"
        >
          <div class="navbar-brand d-flex align-self-start">
            <router-link to="/" class="px-3 logo-granjita"></router-link>
          </div>
          <button
            class="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navbarNav"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span class="navbar-toggler-icon"></span>
          </button>
        </div>
        <div
          class="collapse navbar-collapse flex-lg-row-reverse"
          id="navbarNav"
        >
          <div class="navbar-nav d-inline-block d-lg-flex my-auto">
            <router-link
              v-for="(button, i) in navButtons"
              class="nav-link mx-3"
              :to="button.link"
              :key="i"
            >
              {{ button.label }}
            </router-link>
          </div>
          <div class="social-networks mr-lg-2">
            <div
              class="row no-gutters justify-content-between justify-content-md-center"
            >
              <a
                class="mx-4 my-2 mx-lg-1"
                :class="element.class"
                :href="element.link"
                :target="element.action"
                v-for="element in comunicationMethods"
                :key="element.label"
              >
              </a>
            </div>
          </div>
        </div>
      </div>
    </div>
  </header>
  <slot name="body" v-bind="CPropsRoute" />
  <footer class="bg-dark py-4">
    <div class="container">
      <div
        class="row gy-4 justify-content-center justify-content-lg-between align-items-center"
      >
        <div class="col-md-auto d-md-flex mb-3 mb-md-0">
          <div
            class="mb-3 mx-auto mb-md-0 me-md-3 ms-md-auto d-block d-md-inline responsive-logo-granjita"
          ></div>
          <div class="my-auto">
            <span class="text-white">
              Carr. A las Palmas KM 79, <br />
              Puerto Vallarta Jalisco
            </span>
          </div>
        </div>
        <!-- <div class="col-auto d-none d-lg-block">
          <ul class="list-decoration-none">
            <li v-for="link in navButtons" :key="link.link">
              <router-link class="d-block text-white text-decoration-none" :to="link.link">
                {{ link.label }}
              </router-link>
            </li>
          </ul>
        </div> -->
        <div class="col-md-auto">
          <ul class="list-decoration-none">
            <li
              class="text-center text-md-start"
              v-for="comunication in comunicationMethods"
              :key="comunication.link"
            >
              <a
                :href="comunication.link"
                class="text-decoration-none text-white d-flex justify-content-center justify-content-md-start"
              >
                <div :class="comunication.class" class="me-1"></div>
                <span class="my-auto">{{ comunication.label }}</span>
              </a>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </footer>
</template>
<script>
import { Collapse } from "bootstrap";

export default {
  emits: {
    onLoadLayout: {
      type: Node,
    },
  },
  computed: {
    CNavBar() {
      if (
        this.UI.ScrollY >= window.screen.availHeight * 0.1 ||
        (this.UI.ToggleNavBar && window.innerWidth <= 992)
      ) {
        return {
          class: "navbar-light bg-white",
        };
      } else {
        return {
          class: "navbar-dark bg-gray-blur",
        };
      }
    },
    CPropsRoute() {
      switch (this.$route.name) {
        case "Contacto":
          return { comunication: this.comunicationMethods };
      }
      return [];
    },
  },
  data() {
    return {
      collpaseBar: null,
      navButtons: [
        { link: "/", label: "Inicio" },
        // { link: "/", label: "Ejemplares" },
        { link: "/galeria", label: "Galería" },
        // { link: "/consejos", label: "Consejos" },
        { link: "/contacto", label: "Contacto" },
      ],
      comunicationMethods: [
        {
          link: "https://web.facebook.com/migranjita.paraiso",
          label: "migranjita.paraiso",
          class: "facebook",
          action: "_blank",
          message: "Visitanos",
        },
        {
          link: "https://wa.me/523222668840",
          label: "322-266-8840",
          class: "whatsapp",
          action: "_blank",
          message: "Mandanos un whats",
        },
        {
          link: "tel:322-266-8840",
          label: "322-266-8840",
          class: "phone",
          action: "",
          message: "Llamanos",
        },
        // {
        //   link: "mailto:contacto@migranjitaparaiso.com",
        //   class: "email",
        // },
      ],
      UI: {
        ScrollY: null,
        WindowWidth: null,
        ToggleNavBar: false,
      },
    };
  },
  methods: {
    initComponent() {
      let navBar = document.querySelector("#navbarNav");

      this.collpaseBar = new Collapse(navBar, {
        toggle: false,
      });

      this.$emit("onLoadLayout", this.collpaseBar);

      window.addEventListener("scroll", () => this.watchScroll(window.scrollY));
      window.addEventListener("resize", ({ target }) =>
        this.watchResize(target.innerWidth)
      );
      navBar.addEventListener("shown.bs.collapse", () =>
        this.toggleNavBar(true, "navbar-light bg-white")
      );
      navBar.addEventListener("hidden.bs.collapse", () =>
        this.toggleNavBar(false, "navbar-dark bg-gray-blur")
      );
    },
    toggleNavBar(toggle) {
      this.UI.ToggleNavBar = toggle;
      // cssClass += " fixed-top";
      document.body.setAttribute("show-navbar", toggle);
      // const navBar = this.collpaseBar._element.parentNode.parentNode.parentNode;
      // navBar.classList.remove(...navBar.classList);
      // navBar.classList.add(...cssClass.split(" "));
    },
    watchResize(value) {
      this.UI.WindowWidth = value;
    },
    watchScroll(value) {
      this.UI.ScrollY = value;
    },
  },
  mounted() {
    this.initComponent();
  },
  unmounted() {
    let navBar = document.querySelector("#nav");

    navBar.removeEventListener("shown.bs.collapse", this.toggleNavBar(false));
    navBar.removeEventListener("hide.bs.collapse", this.toggleNavBar(true));
    window.removeEventListener("scroll", this.watchScroll(window.scrollY));
    window.removeEventListener("resize", ({ target }) =>
      this.watchScroll(target.innerWidth)
    );
  },
};
</script>
<style scoped>
footer li:not(li:first-child) {
  margin-top: 0.75rem;
}

.navbar-collapse.collapsing {
  height: 0px !important;
  width: 100%;
}

.navbar-collapse,
header {
  transition: all ease-in-out 0.5s;
}

[show-navbar="true"] header {
  height: 100vh;
}

.navbar-collapse.collapse.show {
  display: flex;
  flex-direction: column;
  height: calc(100% - 3rem) !important;
}

@media (min-width: 992px) {
  [show-navbar="true"] header {
    height: auto;
  }
}
</style>
