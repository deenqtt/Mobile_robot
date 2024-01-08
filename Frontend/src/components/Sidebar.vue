<template>
  <div class="app">
    <aside :class="`${is_expanded ? 'is-expanded' : ''}`">
      <div class="logo">
        <img :src="logoURL" alt="Vue" />
      </div>

      <div class="menu-toggle-wrap">
        <button class="menu-toggle" @click="ToggleMenu">
          <img
            width="24"
            height="28"
            src="https://img.icons8.com/fluency/48/menu--v2.png"
            alt="menu--v2"
          />
        </button>
      </div>

      <h3>Menu</h3>
      <div class="menu">
        <router-link to="/home" class="button">
          <span class="material-icons">home</span>
          <span class="text">Dashboard</span>
        </router-link>
        <router-link to="/report" class="button">
          <span class="material-icons">report</span>
          <span class="text">Report</span>
        </router-link>
        <router-link to="/maps" class="button">
          <span class="material-icons">dashboard</span>
          <span class="text">Maps</span>
        </router-link>
        <router-link to="/robot" class="button">
          <span class="material-icons">group</span>
          <span class="text">Robot</span>
        </router-link>
        <router-link to="/task" class="button">
          <span class="material-icons">edit</span>
          <span class="text">Task Robot</span>
        </router-link>
        <router-link to="/history" class="button">
          <span class="material-icons">history</span>
          <span class="text">History</span>
        </router-link>
        <router-link to="/robot/new" class="button">
          <span class="material-icons">add</span>
          <span class="text">Add New</span>
        </router-link>
      </div>

      <div class="flex"></div>

      <div class="menu">
        <router-link to="/settings" class="button">
          <span class="material-icons">settings</span>
          <span class="text">Settings</span>
        </router-link>
      </div>
    </aside>
  </div>
</template>

<script setup>
import { ref } from "vue";
import logoURL from "../assets/logo1.png";

const is_expanded = ref(localStorage.getItem("is_expanded") === "true");

const ToggleMenu = () => {
  is_expanded.value = !is_expanded.value;
  localStorage.setItem("is_expanded", is_expanded.value);
};
</script>

<style lang="scss" scoped>
:root {
  --primary: #1b4ae7;
  --primary-alt: #5b87e3;
  --grey: #64748b;
  --dark: #1e293b;
  --dark-alt: #334155;
  --light: #e1d7d7;
  --sidebar-width: 400px;
}

button {
  cursor: pointer;
  appearance: none;
  border: none;
  outline: none;
  background: none;
}

.app {
  main {
    flex: 1 1 0;
    padding: 2rem;
  }
}
aside {
  display: flex;
  flex-direction: column;
  background-color: var(--dark);
  color: var(--light);
  width: calc(2rem + 32px);
  overflow: hidden;
  min-height: 100vh;
  padding: 1rem;
  transition: 0.2s ease-in-out;

  .flex {
    flex: 1 1 0%;
  }

  .logo {
    margin-bottom: 1rem;

    img {
      width: 2rem;
    }
  }

  .menu-toggle-wrap {
    display: flex;
    justify-content: flex-end;
    margin-bottom: 1rem;
    position: relative;
    top: 0;
    transition: 0.2s ease-in-out;

    .menu-toggle {
      transition: 0.2s ease-in-out;
      .material-icons {
        font-size: 2rem;
        color: var(--light);
        transition: 0.2s ease-out;
      }

      &:hover {
        .material-icons {
          color: var(--primary);
          transform: translateX(0.5rem);
        }
      }
    }
  }

  h3,
  .button .text {
    opacity: 0;
    transition: opacity 0.3s ease-in-out;
  }

  h3 {
    color: var(--grey);
    font-size: 0.875rem;
    margin-bottom: 0.5rem;
    text-transform: uppercase;
  }

  .menu {
    margin: 0 -1rem;

    .button {
      display: flex;
      align-items: center;
      text-decoration: none;

      transition: 0.2s ease-in-out;
      padding: 0.5rem 1rem;

      .material-icons {
        font-size: 2rem;
        color: var(--light);
        transition: 0.2s ease-in-out;
      }
      .text {
        color: var(--light);
        transition: 0.2s ease-in-out;
      }

      &:hover {
        background-color: var(--dark-alt);

        .material-icons,
        .text {
          color: var(--primary);
        }
      }

      &.router-link-exact-active {
        background-color: var(--dark-alt);
        border-right: 5px solid var(--primary);

        .material-icons,
        .text {
          color: var(--primary);
        }
      }
    }
  }

  .footer {
    opacity: 0;
    transition: opacity 0.3s ease-in-out;

    p {
      font-size: 0.875rem;
      color: var(--grey);
    }
  }

  &.is-expanded {
    width: var(--sidebar-width);

    .menu-toggle-wrap {
      top: -3rem;

      .menu-toggle {
        transform: rotate(-180deg);
      }
    }

    h3,
    .button .text {
      opacity: 1;
    }

    .button {
      .material-icons {
        margin-right: 1rem;
      }
    }

    .footer {
      opacity: 0;
    }
  }

  @media (max-width: 1024px) {
    position: absolute;
    z-index: 99;
  }
}
//for mobile UI
@media screen and (max-width: 600px) {
  aside {
    display: inline;
  }
}
</style>
