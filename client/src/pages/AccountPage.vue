<template>
  <div class="container">
    <section class="row justify-content-center">
      <div class="col-6 text-center">
        <div class="relative mb-5">
          <img class="cover-img rounded" :src="account.coverImg" alt="">
          <div class="centered">
            <img class="rounded-circle picture" :src="account.picture" alt="">

          </div>
        </div>
      </div>
      <div class="d-flex justify-content-center mt-5">
        <h2 class="me-5">{{ account.name }}</h2>
        <button data-bs-toggle="modal" data-bs-target="#editAccountModal" class="btn fs-2" title="Edit Account"><i
            class="mdi mdi-dots-horizontal"></i></button>

      </div>
      <div class="d-flex justify-content-center fw-bold">
        <p> {{ vaults.length }} Vaults</p>
        <p class="mx-2">|</p>
        <p>{{ keeps.length }} Keeps</p>
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
.centered {
  position: absolute;
  left: 50%;
  transform: translate(-50%, -50%);
}

.relative {
  position: relative;
  text-align: center;
  color: white;
  border-radius: 20px;
}

.picture {
  max-height: 20vh;
  max-width: 20vh;
  box-shadow: 2px 10px gray;
}
</style>
