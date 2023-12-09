<template>
  <div class="container-fluid">
    <section class="row">
      <div v-for="keep in keeps" :key="keep.id" class="col-6 col-md-3">
        <KeepsComponent :keep="keep" />
      </div>
    </section>
  </div>
</template>

<script>
import Pop from '../utils/Pop';
import { keepsService } from '../services/KeepsService.js'
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState';
import KeepsComponent from '../components/KeepsComponent.vue';

export default {
  setup() {
    onMounted(() => {
      getKeeps();
    });
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

    };
  },
  components: { KeepsComponent }
}
</script>

<style scoped lang="scss"></style>
