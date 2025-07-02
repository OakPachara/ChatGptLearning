// ... your existing imports
import { createRouter, createWebHistory } from "vue-router";
import type { RouteRecordRaw } from "vue-router";
import Home from "../views/Home.vue";
import About from "../views/About.vue";
import Dashboard from "../views/Dashboard.vue";

// 👇 Export this so it can be imported elsewhere
export const routes: Array<RouteRecordRaw> = [
  {
    path: "/",
    name: "Home",
    component: Home,
    meta: { showInMenu: true , icon: 'mdi-view-dashboard' },
  },
  {
    path: "/about",
    name: "About",
    component: About,
    meta: { showInMenu: true , icon: 'mdi-view-dashboard'},
  },
  {
    path: "/dashboard",
    name: "Dashboard",
    component: Dashboard,
    meta: { showInMenu: true , icon: 'mdi-view-dashboard'},
  },
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;
