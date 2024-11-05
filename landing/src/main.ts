import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import { createRouter, createWebHistory } from "vue-router";
import routes from "./routes";

createApp(App)
  .use(
    createRouter({
      routes,
      history: createWebHistory(),
    })
  )
  .mount("#app");
