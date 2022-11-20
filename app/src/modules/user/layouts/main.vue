<template>
  <header>
    <nav
      class="navbar navbar-expand-lg navbar-light bg-light position-fixed w-100"
    >
      <div class="container-fluid d-flex">
        <div
          class="d-flex col-lg-auto justify-content-between align-self-start"
        >
          <div class="navbar-brand d-flex align-self-start">
            <router-link to="/" class="px-3 logo-granjita"></router-link>
          </div>
        </div>
        <form class="d-flex">
          <div class="input-group">
            <input
              class="form-control d-none d-lg-block"
              type="search"
              placeholder="Search"
              aria-label="Search"
            />
            <button class="bi bi-search input-group-text"></button>
          </div>
        </form>
      </div>
    </nav>
  </header>
  <div id="wrapper">
    <aside id="panelNavigation" class="border-1 border-end bg-white shadow">
      <ul
        class="list-group list-group-flush px-3 d-flex flex-column h-100"
        id="sideNavBar"
      >
        <li class="list-group-item">Test</li>
        <li class="list-group-item">Test</li>
        <li class="list-group-item">Cerrar Sesion</li>
      </ul>
    </aside>
    <article class="my-3 card shadow">
      <router-view></router-view>
    </article>
    <aside id="panelWidgets"></aside>
  </div>
</template>
<script>
export default {
  name: "defaultAdminLayout",
};
</script>
<style>
#panelNavigation {
  display: none;
}

#wrapper {
  padding-top: 4rem;
  display: grid;
  grid-auto-columns: minmax(400px, auto) minmax(max-content, 2fr)
    minmax(400px, auto);
  grid-gap: 1rem;
  grid-auto-rows: minmax(100px, auto);
  min-height: 100vh;
  background-color: #ececec;
}

#sideNavBar > .list-group-item:last-child {
  margin-top: auto;
}

@media (min-width: 992px) {
  #panelNavigation {
    display: block;
    grid-row: 1/4;
    grid-column: 300px;
  }

  #panelWidgets {
    grid-row: 1/4;
  }

  article {
    grid-row: 1/4;
    grid-column: 300px;
  }
}
</style>
