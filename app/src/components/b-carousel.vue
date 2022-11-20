<template>
  <div class="carousel slide" data-bs-ride="carousel" id="galeria">
    <!-- <ol class="carousel-indicators">
            <li v-for="(index, c) in totalSlides" :key="index" data-bs-target="#galeria" :data-bs-slide-to="c"
                :class="c == modelValue ? 'active' : ''" @click="to(c)"></li>
        </ol> -->
    <div class="carousel-inner">
      <slot>
        <div class="carousel-item">
          <slot name="picture" />
        </div>
      </slot>
      <a class="carousel-control-prev" @click="prev()">
        <slot name="arrow-prev" :prev="prev">
          <span class="carousel-control-prev-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Previous</span>
        </slot>
      </a>
      <a class="carousel-control-next" @click="next()">
        <slot name="arrow-prev" :next="next">
          <span class="carousel-control-next-icon" aria-hidden="true"></span>
          <span class="visually-hidden">Next</span>
        </slot>
      </a>
    </div>
  </div>
</template>
<script>
import { Carousel } from "bootstrap";

export default {
  watch: {
    modelValue(newValue) {
      this.to(newValue);
    },
  },
  computed: {
    totalSlides() {
      return this.$slots.default()[0].children.length;
    },
  },
  props: {
    interval: {
      type: Number,
      default: 5000,
    },
    wrap: {
      type: Boolean,
      default: true,
    },
    pause: {
      type: [String, Boolean],
      default: "hover",
    },
    ride: {
      type: [String, Boolean],
      default: false,
    },
    touch: {
      type: Boolean,
      default: true,
    },
    modelValue: {
      type: [Number, String],
      default: 0,
    },
  },
  data() {
    return {
      carousel: null,
      currentPreview: this.modelValue,
    };
  },
  methods: {
    cycle() {
      this.carousel.cycle();
    },
    prev() {
      this.carousel.prev();
    },
    next() {
      this.carousel.next();
    },
    pauseCycle() {
      this.carousel.pause();
    },
    onSlide(event) {
      this.$emit("slide", event);
    },
    onSlid(event) {
      this.currentPreview = event.to;
      this.$emit("slid", event);
      this.$emit("update:modelValue", event.to);
    },
    dispose() {
      this.carousel.dispose();
    },
    to(index) {
      this.carousel.to(index);
    },
  },
  mounted() {
    const firstPicture = this.$el.querySelector(".carousel-item");

    if (firstPicture) {
      firstPicture.classList.add("active");
    }

    const options = {
      interval: this.interval,
      wrap: this.wrap,
      ride: this.ride,
      touch: this.touch,
    };

    this.carousel = new Carousel(this.$el, options);
    this.$el.addEventListener("slide.bs.carousel", this.onSlide);
    this.$el.addEventListener("slid.bs.carousel", this.onSlid);

    this.$emit("carousel-loaded", {
      cycle: this.carousel.cycle,
      pauseCycle: this.carousel.pause,
      prev: this.carousel.prev,
      next: this.carousel.next,
      nextWhenVisible: this.nextWhenVisible,
      dispose: this.dispose,
    });
  },
};
</script>
