<template>
  <div class="container-fluid">
    <section v-if="account.id" class="row justify-content-center">
      <div class="col-2">
        <button class="mx-1" data-bs-toggle="modal" data-bs-target="#createKeep">Create Keep</button>
        <button class="mx-1" data-bs-toggle="modal" data-bs-target="#createVault">Create Vault</button>
        <!-- <form>
          <label for="option" class="form-label"></label>
          <select name="" id="" class="form-select">
            <option data-bs-toggle="modal" data-bs-target="#createKeep" value="">New Keep</option>
            <option data-bs-toggle="modal" data-bs-target="#createVault" value="">New Vault</option>
          </select>
        </form> -->
      </div>
    </section>
    <section class="row">
      <div v-for="keep in keeps" :key="keep.id" class="col-6 col-md-3">
        <KeepsComponent :keep="keep" />
      </div>

    </section>
  </div>
  <CreateVaultModal />
  <CreateKeepModal />
  <ActiveKeepModal />
</template>

<script>
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService.js'
import { computed, onMounted, watch, watchEffect } from 'vue';
import { AppState } from '../AppState';
import KeepsComponent from '../components/KeepsComponent.vue';
import ActiveKeepModal from '../components/ActiveKeepModal.vue';
import CreateKeepModal from '../components/CreateKeepModal.vue';
import CreateVaultModal from '../components/CreateVaultModal.vue';

export default {
  setup() {
    watch(() => {
      getKeeps()
    }, { immediate: true }
    );

    async function getKeeps() {
      try {
        await keepsService.getKeeps();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    return {
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account)

    };
  },
  components: { KeepsComponent, ActiveKeepModal, CreateVaultModal, CreateKeepModal }
}
</script>

<style scoped lang="scss"></style>
