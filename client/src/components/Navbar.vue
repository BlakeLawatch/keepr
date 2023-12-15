<template>
  <nav class="navbar navbar-expand-sm navbar-dark px-3">
    <router-link class="navbar-brand d-flex" title="Home Page" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo" src="src/assets/img/K-removebg-preview.png" height="75" />
      </div>
    </router-link>
    <div class="dropdown">
      <button class="btn btn-outline dropdown-toggle text-center" type="button" data-bs-toggle="dropdown"
        aria-expanded="false">
        Create
      </button>
      <ul class="dropdown-menu">
        <li class="ms-1" type="button" data-bs-toggle="modal" data-bs-target="#createKeep">Create Keep</li>
        <li class="ms-1" type="button" data-bs-toggle="modal" data-bs-target="#createVault">Create Vault</li>
      </ul>
    </div>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText"
      aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">

      </ul>
      <!-- LOGIN COMPONENT HERE -->
      <!-- <div>
        <button class="btn text-light" @click="toggleTheme"><i class="mdi"
            :class="theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'"></i></button>
      </div> -->
      <Login />
    </div>
  </nav>
</template>

<script>
import { onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from './Login.vue';
export default {
  setup() {

    const theme = ref(loadState('theme') || 'light')

    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })

    return {
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
