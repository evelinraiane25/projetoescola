import Vue from "vue";
import App from "./App.vue";
import { store } from "./store";

Vue.config.productionTip = false

// Filters
import "@/utils/filters";

new Vue({
  store,
  render: (h) => h(App),
}).$mount("#app");
