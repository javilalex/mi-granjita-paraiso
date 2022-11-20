<template>
  <component :is="$route.meta.layout" @on-load-layout="onLoadLayout">
    <template #body="layoutProps">
      <router-view v-bind="layoutProps" #default="{ Component }">
        <transition name="fade" mode="out-in" appear>
          <div class="d-flex flex-column flex-grow-1">
            <component :is="Component" />
          </div>
        </transition>
      </router-view>
      <vue-progress-bar></vue-progress-bar>
    </template>
  </component>
</template>

<script>
export default {
  data() {
    return {
      Collapse: null,
    };
  },
  computed: {},
  methods: {
    onLoadLayout(node) {
      this.Collapse = node;
    },
  },
  mounted() {
    this.$router.afterEach(() => {
      //  finish the progress bar
      this.$Progress.finish();
      if (this.Collapse) this.Collapse.hide();
    });
  },
  created() {
    //  [App.vue specific] When App.vue is first loaded start the progress bar
    this.$Progress.start();
    //  hook the progress bar to start before we move router-view
    this.$router.beforeEach((to, from, next) => {
      from;
      //  does the page we want to go to have a meta.progress object
      if (to.meta.progress !== undefined) {
        let meta = to.meta.progress;
        // parse meta tags
        this.$Progress.parseMeta(meta);
      }
      //  start the progress bar
      this.$Progress.start();
      //  continue to next page
      next();
    });
  },
};
</script>
