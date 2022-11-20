import defaultLayout from "../layouts/main.vue";

// const beforeToReachProtectedRoute = (_, __, next) => {
//   if (!localStorage.getItem("session-details")) next({ name: "Login" });
// };

export default [
  {
    path: "/login",
    name: "Login",
    component: () =>
      import(/* webpackChunkName: "login" */ "../views/login.vue"),
    meta: {
      layout: defaultLayout,
    },
  },
  {
    path: "",
    name: "Dashboard",
    component: () =>
      import(/* webpackChunkName: "dashboard" */ "../views/dashboard.vue"),
    // beforeEnter: beforeToReachProtectedRoute,
    meta: {
      layout: defaultLayout,
    },
  },
];
