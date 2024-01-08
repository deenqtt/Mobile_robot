<template>
  <!-- Navbar -->
  <nav class="navbar navbar-expand-lg bg-white navbar-light">
    <div class="container">
      <div id="navigation" class="collapse navbar-collapse">
        <ul class="navbar-nav">
          <div class="nav1">
            <li class="nav-item">
              <router-link
                class="nav-link d-flex align-items-center me-2 active"
                aria-current="page"
                to="/home"
              >
                <i
                  class="fa fa-chart-pie opacity-6 me-1"
                  aria-hidden="true"
                ></i>
                Dashboard
              </router-link>
            </li>
          </div>

          <div class="nav2">
            <li class="nav-item">
              <router-link class="nav-link me-2" to="/profile">
                <i class="fa fa-user opacity-6 me-1" aria-hidden="true"></i>
                Profile
              </router-link>
            </li>
          </div>
          <div class="nav3">
            <li class="nav-item">
              <button class="nav-link me-2" @click="logout">
                <i
                  class="fas fa-user-circle opacity-5 me-1"
                  aria-hidden="true"
                ></i>
                Logout
              </button>
            </li>
          </div>
          <div class="nav4">
            <li class="nav-item">
              <router-link class="nav-link me-2" to="/">
                <i class="fas fa-key opacity-6 me-1" aria-hidden="true"></i>
                Sign In
              </router-link>
            </li>
          </div>
        </ul>
      </div>
    </div>
  </nav>
  <!-- End Navbar -->
</template>

<script>
import { useRouter } from "vue-router";

export default {
  setup() {
    const router = useRouter();
    const logout = () => {
      localStorage.setItem("authenticated", false);
      router.push({ name: "Login" });
    };
    return { logout };
  },
};
</script>
<style lang="scss" scoped>
button {
  cursor: pointer;
  background: none;
  border: none;
  font-family: Poppins, sans-serif;
  font-weight: 300;
}
.navbar .nav2 .nav-item {
  font-family: Poppins, sans-serif;
  margin-left: -50px;
  margin-right: 25px;
}
.navbar .nav3 .nav-item {
  font-family: Poppins, sans-serif;
  margin-right: 20px;
}
.navbar .nav4 .nav-item {
  font-family: Poppins, sans-serif;
}
.navbar {
  margin-top: -30px;
  margin-left: -30px;
}

.nav1 .nav-item {
  font-family: Poppins, sans-serif;
  font-size: 30px;
  margin-right: 550px;
}
.navbar .nav-item::after {
  content: "";
  display: block;
  border-bottom: 0.1rem solid #0a0909;
  transform: scaleX(0);
  transition: 0.2s linear;
}
.navbar .nav-item:hover::after {
  transform: scaleX(0.5);
}
//mobile phone
@media screen and (max-width: 680px) {
  .navbar {
    font-size: 55%;
  }
}
</style>
