<template>
  <header>
    <nav class="navbar navbar-expand-lg navbar-light bg-light position-fixed w-100">
      <div class="container-fluid d-flex">
        <div class="d-flex col-lg-auto justify-content-between align-self-start">
          <div class="navbar-brand d-flex align-self-start">
            <router-link to="/" class="px-3 logo-granjita"></router-link>
          </div>
        </div>
        <form class="d-flex">
          <div class="input-group">
            <input class="form-control d-none d-lg-block" type="search" placeholder="Search" aria-label="Search" />
            <button class="bi bi-search input-group-text"></button>
          </div>
        </form>
      </div>
    </nav>
  </header>
  <div id="wrapper">
    <aside id="panelNavigation" class="border-1 border-end bg-white shadow">
      <ul class="list-group list-group-flush px-3 d-flex flex-column h-100 text-start" id="sideNavBar">
          <li class="list-group-item">
              <i class="bi bi-briefcase-fill"></i>
              Items
          </li>
        <li class="list-group-item">Test</li>
        <li class="list-group-item">
            <i class="bi bi-box-arrow-in-left"></i>
            Cerrar Sesion
        </li>
      </ul>
    </aside>
    <router-view></router-view>
  </div>
</template>
<script>
export default {
  name: "defaultAdminLayout",
};
</script>
<style>
#panelNavigation,
aside#panelWidgets {
  display: none;
}

#wrapper {
  padding-top: 4rem;
  display: grid;
  grid-template-columns: minmax(max-content, 2fr);
  grid-gap: 1rem;
  grid-auto-rows: minmax(100px, auto);
  min-height: 100vh;
  background-color: #ececec;
}

#sideNavBar>.list-group-item:last-child {
  margin-top: auto;
}

    #wrapper>*:not(#panelNavigation):not(*.not-my-3){
        margin-top: 1rem;
        margin-bottom: 1rem;
    }

    #wrapper > article {
        margin: 1rem;
    }

    #panelNavigation > ul > li{
        padding: .75rem 1rem;
    }


    @media (min-width: 992px) {
        #wrapper {
    grid-template-columns: 350px minmax(max-content, 2fr) 400px;
  }

  #wrapper>*:nth-child(2) {
    margin-right: 1rem;
  }

  #panelNavigation,
  aside#panelWidgets {
    display: block;
  }

  #panelNavigation {
    grid-column: 1/1;
    grid-row: 1/2;
  }

  aside#panelWidgets {
    grid-column: 3/3;
    grid-row: 1/2;
  }

  #wrapper>article {
    margin-left: 0rem;
    margin-right: 0rem;
    grid-column: 2/4;
    grid-row: 1/2;
  }

  #wrapper>aside#panelWidgets+article,
  #wrapper>.container {
    grid-column: 2/3;
  }
}
</style>
