<template>
  <header class="sticky-top">
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <CreateVaultModal />
  <CreateKeepModal />
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'
import Pop from './utils/Pop'
import { accountService } from './services/AccountService'
import CreateVaultModal from './components/CreateVaultModal.vue'
import CreateKeepModal from './components/CreateKeepModal.vue'

export default {
  setup() {


    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, CreateVaultModal, CreateKeepModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


.profile {
  height: 5vh;
  width: 5vh;
  border-radius: 50%;
}

.info-text-shadow {
  text-shadow: 3px 3px 2px #bfe5ec;
}
</style>
