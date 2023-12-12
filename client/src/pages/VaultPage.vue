<template>
    <div v-if="activeVault" class="container">
        <section class="row justify-content-center">
            <div class="col-12 col-md-3 bg-img text-center d-flex align-items-end">
                <div>
                    <p class="text-light fw-bold fs-4">{{ activeVault.name }}</p>
                    <p class="text-light fw-bold fs-6">By {{ activeVault.creator.name }}</p>
                </div>
            </div>
            <div class="col-6 col-md-3">
                {{ vaultKeeps }}

            </div>
        </section>
    </div>
</template>


<script>
import { computed, onMounted } from 'vue';
import { vaultsService } from '../services/VaultsService';
import Pop from '../utils/Pop';
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState.js'
import { keepsService } from '../services/KeepsService';


export default {
    setup() {
        const route = useRoute()
        const router = useRouter()
        onMounted(() => {
            getVaultById()
            getKeepByVaultId()
        })

        async function getVaultById() {
            try {
                const vaultId = route.params.vaultId
                await vaultsService.getVaultById(vaultId)

            } catch (error) {
                Pop.error(error);
                if (error.response.data.includes('go there')) {
                    router.push({ name: 'Home' })
                }
            }
        }

        async function getKeepByVaultId() {
            const vaultId = route.params.vaultId
            keepsService.getKeepByVaultId(vaultId)
        }


        return {
            activeVault: computed(() => AppState.activeVault),
            vaultKeeps: computed(() => AppState.vaultKeeps),
            coverImg: computed(() => `url(${AppState.activeVault?.img})`)
        }
    }
};
</script>


<style lang="scss" scoped>
.bg-img {
    background-image: v-bind(coverImg);
    background-position: center;
    background-size: cover;
    height: 20vh;

}
</style>