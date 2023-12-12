<template>
  <div class="container">
    <section class="row">
      <div class="col-12">
        <button data-bs-toggle="modal" data-bs-target="#editAccountModal" class="btn">Edit Account</button>
        <img :src="account.coverImg" alt="">
        <img :src="account.picture" alt="">
        <p>{{ account.name }}</p>
      </div>
    </section>
    <section class="row">
      <h3>Vaults</h3>
      <div v-for="vault in vaults" :key="vault.id" class="col-6 col-md-3">
        <VaultsComponent :vault="vault" />
      </div>
      <h3>Keeps</h3>
      <div v-for="keep in keeps" :key="keep.id" class="col-6 col-md-3">
        <KeepsComponent :keep="keep" />
      </div>
    </section>
  </div>
  <EditAccountModal />
</template>

<script>
import { computed, onMounted, watch } from 'vue';
import { AppState } from '../AppState';
import KeepsComponent from '../components/KeepsComponent.vue';
import EditAccountModal from '../components/EditAccountModal.vue';
import Pop from '../utils/Pop';
import { accountService } from '../services/AccountService';
import VaultsComponent from '../components/VaultsComponent.vue';
export default {
  setup() {
    watch(() => {
      getMyVaults()

    })

    async function getMyVaults() {
      try {
        await accountService.getMyVaults()
      } catch (error) {
        Pop.error(error)
      }
    }



    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepsComponent, EditAccountModal, VaultsComponent }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
