<template>
  <div class="container">
    <section class="row justify-content-center">
      <div class="col-6 text-center">
        <div>
          <img class="cover-img" :src="account.coverImg" alt="">
        </div>
        <div>
          <img class="rounded-circle" :src="account.picture" alt="">

        </div>
        <div class="d-flex justify-content-around">
          <h2>{{ account.name }}</h2>
          <button data-bs-toggle="modal" data-bs-target="#editAccountModal" class="btn fs-2" title="Edit Account"><i
              class="mdi mdi-dots-horizontal"></i></button>

        </div>
      </div>
    </section>
    <section class="row">
      <h3>Vaults</h3>
      <div v-for="vault in vaults" :key="vault.id" class="col-6 col-md-3">
        <!-- {{ vault.description }} -->
        <VaultsComponent :vault="vault" />
      </div>
      <h3 class="mt-5 mb-2">Keeps</h3>
      <div v-for="keep in keeps" :key="keep.id" class="col-6 col-md-3">
        <KeepsComponent :keep="keep" />
      </div>
    </section>
  </div>
  <EditAccountModal />
</template>

<script>
import { computed, watch } from 'vue';
import { AppState } from '../AppState';
import KeepsComponent from '../components/KeepsComponent.vue';
import EditAccountModal from '../components/EditAccountModal.vue';
import Pop from '../utils/Pop';
import { accountService } from '../services/AccountService';
import VaultsComponent from '../components/VaultsComponent.vue';
import { useRoute } from 'vue-router';
import { profilesService } from '../services/ProfilesService';

export default {
  setup() {
    const route = useRoute()
    watch(() => {
      getMyVaults()
      getUsersKeeps()
    })

    async function getMyVaults() {
      try {
        await accountService.getMyVaults()
      } catch (error) {
        Pop.error(error)
      }
    }
    async function getUsersKeeps() {
      try {

        const profileId = AppState.account.id
        await profilesService.getUsersKeeps(profileId);
      }
      catch (error) {
        Pop.error(error);
      }
    }





    return {
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.accountVaults),
      keeps: computed(() => AppState.profileKeeps)
      // keeps: computed(() => AppState.keeps.filter(keeps => keeps.creatorId = AppState.account?.id))
    };
  },
  components: { KeepsComponent, EditAccountModal, VaultsComponent }
}
</script>

<style scoped>
.cover-img {
  object-position: center;
  object-fit: cover;
  width: 30em;
}


img {
  max-width: 100px;
}
</style>
