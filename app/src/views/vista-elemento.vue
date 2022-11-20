<template>
  <div class="container my-xl-5 flex-grow-1 card shadow-sm">
    <div class="row">
      <div class="card-body p-4">
        <div class="row">
          <div class="col-lg-5">
            <swiper :breakpoints="settings" lazy loop class="rounded mb-2">
              <swiper-slide v-for="i in 5" :key="i">
                <img
                  src="https://via.placeholder.com/600"
                  class="rounded w-100"
                  alt=""
                />
              </swiper-slide>
            </swiper>
            <swiper
              :slidesPerView="3.5"
              :spaceBetween="10"
              centered-slides
              loop
            >
              <swiper-slide v-for="i in 5" :key="i">
                <img
                  src="https://via.placeholder.com/600"
                  class="rounded w-100"
                  alt=""
                />
              </swiper-slide>
            </swiper>
          </div>
          <div class="col-lg-7 text-start">
            <h1>Title</h1>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import { Swiper, SwiperSlide } from "swiper/vue";

export default {
  components: {
    Swiper,
    SwiperSlide,
  },
  props: {
    source: String,
    type: String,
    Item: String,
  },
  data() {
    return {
      settings: {
        0: {
          slidesPerView: 1,
        },
        // when window width is >= 480px
        768: {
          slidesPerView: 1.3,
          spaceBetween: 10,
          centeredSlides: true,
        },
      },
    };
  },
};
</script>
<style></style>
