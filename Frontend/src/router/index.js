import { createRouter, createWebHistory } from "vue-router";
import Loginview from "../pages/LoginView.vue";
import Homeview from "../view/Home.vue";
const router = createRouter({
  history: createWebHistory(),
  routes: [
    {
      path: "/",
      name: "Login",
      component: Loginview,
    },
    {
      path: "/register",
      name: "Register",
      component: () => import("../pages/Register.vue"),
      meta: {
        requiresAuth: false, // Set to true for protected routes
      },
    },
    {
      path: "/home",
      name: "Dashboard",
      component: Homeview,
    },
    {
      path: "/report",
      component: () => import("../view/Report.vue"),
    },
    {
      path: "/history",
      component: () => import("../view/history.vue"),
    },
    {
      path: "/maps",
      component: () => import("../view/Maps.vue"),
    },
    {
      path: "/robot",
      component: () => import("../view/Robot.vue"),
    },
    {
      path: "/robot/new",
      component: () => import("../view/New.vue"),
    },
    {
      path: "/settings",
      component: () => import("../view/Setting.vue"),
    },
    {
      path: "/task",
      component: () => import("../view/Task.vue"),
    },
    {
      path: "/battery",
      component: () => import("../pages/Batery.vue"),
    },
    {
      path: "/mapping",
      component: () => import("../pages/Mapping.vue"),
    },
    {
      path: "/docking",
      component: () => import("../pages/Docking.vue"),
    },
    {
      path: "/erorhandling",
      component: () => import("../pages/Eror.vue"),
    },
    {
      path: "/planner",
      component: () => import("../pages/Planner.vue"),
    },
    {
      path: "/profile",
      component: () => import("../pages/Profile.vue"),
    },
    {
      path: "/wifi",
      component: () => import("../pages/Wifi.vue"),
    },
    {
      path: "/date",
      component: () => import("../pages/Date.vue"),
    },
  ],
});

router.beforeEach((to, from, next) => {
  console.log("Navigation guard triggered");
  const isAuthenticated = JSON.parse(localStorage.getItem("authenticated"));

  if (!isAuthenticated && to.meta.requiresAuth) {
    console.log("Redirecting to Login");
    next({ name: "Login" });
  } else if (isAuthenticated && to.name === "Login") {
    console.log("Redirecting to Dashboard");
    next({ name: "Dashboard" });
  } else {
    console.log("Continuing with navigation");
    next();
  }
});

export default router;
