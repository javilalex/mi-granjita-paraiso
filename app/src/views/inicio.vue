<template>
  <section>
    <div class="d-flex vh-100 parallax-main-photo picture-background">
      <div class="container my-auto">
        <div
          class="logo-granjita mx-auto mb-5"
          id="top-mi-granjita-paraiso"
        ></div>
      </div>
    </div>
  </section>
  <section>
    <div class="container my-5">
      <div class="row">
        <div class="col-12">
          <div class="card">
            <div class="card-body pb-xl-5 px-xl-5 pt-xl-4">
              <div class="row gy-4 justify-content-lg-between">
                <div class="col-12">
                  <h2 class="display-6">Nuestros ejemplares en venta</h2>
                </div>
                <div class="col-12 h-100">
                  Lorem ipsum dolor sit amet consectetur adipisicing elit. Quo
                  veniam maxime odit, quasi veritatis dolorum laboriosam
                  dignissimos nulla quisquam ea dolor fuga cum facilis itaque
                  officiis molestiae at assumenda tempora.
                </div>
                <div class="col-lg" v-for="i in 4" :key="i">
                  <div class="card" style="height: 400px">
                    <div class="card-body"></div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
</template>

<script>
// @ is an alias to /src

export default {
  name: "pagina-inicio",
  components: {},
  data() {
    return {
      text: null,
    };
  },
  methods: {},
};
</script>
