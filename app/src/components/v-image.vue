<template>
  <img
    src="../../src/assets/img/doge.png"
    alt=""
    @load="imageLoaded"
    v-show="Load"
  />
  <div class="spinner-grow spinner-grow-sm" v-show="!Load"></div>
</template>

<script>
export default {
  emits: {},
  computed: {},
  data() {
    return {
      Load: false,
    };
  },
  methods: {
    imageLoaded() {
      this.Load = true;
    },
  },
  mounted() {},
  unmounted() {},
};
</script>
