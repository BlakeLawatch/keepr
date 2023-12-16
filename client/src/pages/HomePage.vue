<template>
  <div class="container my-5">
    <section v-if="account.id" class="row justify-content-center">
      <div class="col-3 d-flex my-2">
      </div>
    </section>
    <section class="masonry">
      <div @click="getKeepById()" v-for="keep in keeps" :key="keep.id">
        <KeepsComponent :keep="keep" />
      </div>
    </section>
  </div>

  <ActiveKeepModal />
</template>

<script>
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService.js'
import { computed, watch } from 'vue';
import { AppState } from '../AppState';
import KeepsComponent from '../components/KeepsComponent.vue';
import ActiveKeepModal from '../components/ActiveKeepModal.vue';

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
      account: computed(() => AppState.account),

      async getKeepById() {
        try {

          const keepId = AppState.activeKeep?.id
          await keepsService.getKeepById(keepId)
        } catch (error) {
          Pop.error(error)
        }
      },

    };
  },
  components: { ActiveKeepModal, KeepsComponent }
}
</script>

<style scoped lang="scss">
.masonry {
  columns: 250px;
}

@media (max-width: 845px) {
  .masonry {
    columns: 200px
  }
}
</style>
