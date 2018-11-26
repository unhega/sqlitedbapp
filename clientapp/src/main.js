import "@babel/polyfill";
import Vue from "vue";
import "./plugins/bootstrap-vue";
import "./plugins/axios";
import App from "./App.vue";
import router from "./router";
import VueHighcharts from "vue-highcharts";

Vue.use(VueHighcharts);

Vue.config.productionTip = false;

new Vue({
  router,
  render: h => h(App)
}).$mount("#app");
