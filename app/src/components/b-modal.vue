<template>
  <div
    class="modal fade"
    :id="id"
    tabindex="-1"
    aria-labelledby="modal"
    aria-hidden="false"
  >
    <div
      :class="`modal-dialog modal-dialog-centered modal${
        size ? '-' + size : ''
      }`"
    >
      <div class="modal-content">
        <div class="modal-header" v-if="$slots.header">
          <slot name="header"></slot>
        </div>
        <div class="modal-header" v-else-if="!hideHeader">
          <h5 class="modal-title">{{ title }}</h5>
          <button
            type="button"
            class="btn-close"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <slot name="content">
          <div class="modal-body">
            <slot></slot>
          </div>
        </slot>
      </div>
      <div class="modal-footer" v-if="$slots.footer && !hideFooter">
        <slot name="footer"></slot>
      </div>
    </div>
  </div>
</template>

<script>
import { Modal } from "bootstrap";

export default {
  props: {
    id: {
      type: String,
      default: "bootstrapmodal",
    },
    keyboard: {
      type: Boolean,
      default: true,
    },
    backdrop: {
      type: Boolean,
      default: true,
    },
    focus: {
      type: Boolean,
      default: false,
    },
    size: {
      type: String,
      default: "md",
    },
    hideFooter: {
      type: Boolean,
      default: false,
    },
    hideHeader: {
      type: Boolean,
      default: false,
    },
    title: {
      type: String,
    },
  },
  computed: {},
  data() {
    return {
      modal: null,
    };
  },
  methods: {
    initmodal() {
      this.modal = new Modal(this.$el, {
        keyboard: this.keyboard,
        backdrop: this.backdrop,
        focus: this.focus,
      });

      this.$emit("modal-loaded", {
        toggle: this.toggle,
        show: this.show,
        hide: this.hide,
        handleUpdate: this.handleUpdate,
        dispose: this.dispose,
      });

      this.$el.addEventListener("show.bs.modal", this.onShow);
      this.$el.addEventListener("shown.bs.modal", this.onShown);
      this.$el.addEventListener("hide.bs.modal", this.onHide);
      this.$el.addEventListener("hidden.bs.modal", this.onHidden);
      this.$el.addEventListener("hidePrevented.bs.modal", this.onHidePrevented);
    },
    toggle() {
      this.modal.toggle();
    },
    show() {
      this.modal.show();
    },
    hide() {
      this.modal.hide();
    },
    handleUpdate() {
      this.modal.handleUpdate();
    },
    dispose() {
      this.modal.dispose();
    },
    onShow(event) {
      this.$emit("show", event);
    },
    onShown(event) {
      this.$emit("shown", event);
    },
    onHide(event) {
      this.$emit("hide", event);
    },
    onHidden(event) {
      this.$emit("hidden", event);
    },
    onHidePrevented(event) {
      this.$emit("hide-prevented", event);
    },
  },
  mounted() {
    this.initmodal();
  },
  created() {},
  unmounted() {
    this.dispose();

    this.$el.removeEventListener("show.bs.modal", this.onShow);
    this.$el.removeEventListener("shown.bs.modal", this.onShown);
    this.$el.removeEventListener("hide.bs.modal", this.onHide);
    this.$el.removeEventListener("hidden.bs.modal", this.onHidden);
    this.$el.removeEventListener(
      "hidePrevented.bs.modal",
      this.onHidePrevented
    );
  },
};
</script>
