<template>
  <div class="app">
    <!-- Sidebar -->
    <Sidebar v-if="showSidebarAndHeader" />
    <!-- Header -->
    <main>
      <Header v-if="showSidebarAndHeader" />
      <!-- Content -->
      <router-view />
    </main>
  </div>
</template>

<script>
import Header from "./components/Header.vue";
import Sidebar from "./components/Sidebar.vue";

export default {
  name: "App",
  components: {
    Header,
    Sidebar,
  },
  computed: {
    showSidebarAndHeader() {
      const exemptedPages = ["/", "/register", "/profile"];
      const isExemptedPage = exemptedPages.includes(this.$route.path);

      return !isExemptedPage;
    },
  },
};
</script>

<style lang="scss">
:root {
  --primary: #1b4ae7;
  --primary-alt: #5b87e3;
  --grey: #64748b;
  --dark: #1e293b;
  --dark-alt: #334155;
  --light: #e1d7d7;
  --sidebar-width: 400px;
}

.app {
  display: flex;
  main {
    flex: 2;
    padding: 2rem;
  }
}
@media (max-width: 1366px) {
  .app {
    font-size: 75%;
  }
}

//tablet
@media (max-width: 758px) {
  .app {
    font-size: 62.5%;
  }
}
//mobile
@media (max-width: 480px) {
  .app {
    font-size: 40%;
  }
}
</style>
