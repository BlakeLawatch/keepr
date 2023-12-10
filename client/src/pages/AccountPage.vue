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
    <section>
      <div class="col-6 col-md-3">
        Vaults will go here
      </div>
      <div v-for="keep in keeps" :key="keep.id" class="col-6 col-md-3">
        <KeepsComponent />
      </div>
    </section>
  </div>
  <EditAccountModal />
</template>

<script>
import { computed } from 'vue';
import { AppState } from '../AppState';
import KeepsComponent from '../components/KeepsComponent.vue';
import EditAccountModal from '../components/EditAccountModal.vue';
export default {
  setup() {
    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepsComponent, EditAccountModal }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
