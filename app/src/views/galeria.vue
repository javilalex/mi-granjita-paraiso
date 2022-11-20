<template>
  <div class="container mb-5">
    <h1 class="display-3 fw-bold my-4 title-area">Galeria</h1>
    <div class="container-lg mb-4">
      <transition-group name="slide-fade" appear tag="div" class="row g-4">
        <div
          class="col-md-6 col-lg-4"
          v-for="(image, index) in Images"
          :key="index"
          id="galleryContainer"
        >
          <div class="card shadow rounded-3 overflow-hidden">
            <div class="ratio ratio-4x3" @click="setImage(index)">
              <img
                :src="image.src"
                class="card-img-top img-responsive"
                style="backgound-position: center"
                alt=""
              />
            </div>
            <div class="card-body">
              <h4 class="card-text">{{ image.title }}</h4>
              <p class="text-start">{{ image.description }}</p>
              <button
                class="btn btn-primary w-100 rounded-pill"
                @click="setImage(index)"
              >
                Mas informacion
              </button>
            </div>
          </div>
        </div>
      </transition-group>
    </div>
    <b-modal
      hide-header
      size="xl"
      ref="modal"
      @modal-loaded="onModalLoaded"
      @hidden="onHideModal"
      @shown="modalShow = 1"
    >
      <template #content>
        <div class="modal-body p-0">
          <div class="row gx-0">
            <div class="col-xl-8">
              <b-carousel
                v-model="currentImage"
                @slide="$router.push(`/galeria/${currentImage}`)"
              >
                <div
                  class="carousel-item"
                  v-for="(image, index) in Images"
                  :key="index"
                >
                  <div class="ratio ratio-4x3">
                    <img
                      class="img-responsive rounded-3"
                      :src="image.src"
                      :alt="image.alt"
                    />
                  </div>
                </div>
              </b-carousel>
            </div>
            <div
              class="col-xl-4 text-start d-flex flex-lg-grow-1 flex-column p-3"
              v-if="selectedPicture"
            >
              <h3
                class="border-bottom border-3 border-primary border-opacity-50"
              >
                {{ selectedPicture.title }}
              </h3>
              <button
                class="btn-close position-absolute"
                style="top: 1rem; right: 1rem; z-index: 3"
                @click="modal.hide()"
              ></button>
              <p>
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Quis,
                minus! Temporibus soluta provident, dolor, culpa totam nostrum
                eligendi beatae natus, quis ipsam ab eum earum pariatur nemo rem
                excepturi veniam?
              </p>
              <h5>Caracteristicas</h5>
              <ul>
                <li>Color: Crema</li>
              </ul>
              <button class="btn btn-primary mt-auto rounded-pill">
                Mas informacion
              </button>
            </div>
          </div>
        </div>
      </template>
    </b-modal>
  </div>
</template>
<script>
import { BCarousel, BModal } from "@/components/";
// import VImage from "../components/v-image.vue";

const getURL = (url) => {
  return new URL(url, import.meta.url).href;
};

export default {
  name: "pagina-galeria",
  components: {
    BCarousel,
    BModal,
    // VImage
  },
  watch: {},
  props: {
    propsRoute: {
      type: Object,
    },
  },
  computed: {
    selectedPicture() {
      return this.Images[this.currentImage];
    },
  },
  data() {
    return {
      modal: {},
      currentImage: null,
      Images: [
        {
          src: getURL("/src/assets/img/1617573388396.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388344.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388353.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388358.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388363.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388368.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388372.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388377.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388381.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388385.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388390.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
        {
          src: getURL("/src/assets/img/1617573388393.jpg"),
          title: "Title",
          description:
            "Lorem ipsum dolor sit amet consectetur adipisicing elit. Unde exercitationem rem saepe soluta deleniti enim perferendis laudantium obcaecati distinctio vel, doloremque illum molestiae voluptate reprehenderit? Dolor ratione molestiae architecto neque?",
          label: "Text label",
        },
      ],
      modalShow: false,
    };
  },
  methods: {
    setImage(index) {
      if (!this.modalShow) this.modal.show();
      this.currentImage = index;
      /* eslint-disable */
      this.$router.push(`/galeria/${index}`);
    },
    showImage(index) {
      this.modal.show();
      this.currentImage = index;
    },
    onModalLoaded(methods) {
      this.modal = methods;
    },
    onHideModal() {
      this.$router.push('/galeria');
      this.modalShow = false;
    }
  },
  mounted() {

    if (this.$route.params.img) {
      this.showImage(this.$route.params.img);
    }

    this.$router.afterEach((to) => {
      if (to.params.img) {
        this.showImage(Number(to.params.img));
      } else {
        this.CurrentImage = null;
      }
    });
  },
  created() {
  },
  unmounted() {
  },
};
</script>
<style scoped>
.rounded-top-0 {
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}

.rounded-bottom-start-0 {
  border-bottom-left-radius: 0;
}

.my-n-3 {
  margin-top: -1rem;
  margin-bottom: -1rem;
}
</style>
