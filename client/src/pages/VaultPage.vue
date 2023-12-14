<template>
    <div v-if="activeVault" class="container">
        <section class="row justify-content-center">
            <div class="col-12 col-md-3 bg-img text-center d-flex align-items-end">
                <div>
                    <p class="text-light fw-bold fs-4 text-shadow">{{ activeVault.name }}</p>
                    <p class="text-light fw-bold fs-6">By {{ activeVault.creator.name }}</p>
                </div>
            </div>
            <div class="text-center">
                <p class="fw-bold fs-3">{{ keepsInVaults?.length }} Keeps</p>

            </div>
        </section>
        <section class="row">
            <h3>Keeps</h3>
            <div class="col-6 col-md-3 bg-keep" v-for="keepsInVault in keepsInVaults" :key="keepsInVault.id">
                <img class="img-fluid" :src="keepsInVault.img" alt="">
                <p>{{ keepsInVault.name }}</p>
                <button v-if="activeVault.creatorId == account.id" class="btn btn-outline-danger"
                    @click="destroyKeepFromVault(keepsInVault.vaultKeepId)">Delete from
                    Vault</button>

            </div>



        </section>
    </div>
</template>


<script>
import { computed, watch } from 'vue';
import { vaultsService } from '../services/VaultsService';
import Pop from '../utils/Pop';
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState.js'
import { keepsService } from '../services/KeepsService';


export default {
    setup() {
        const route = useRoute()
        const router = useRouter()
        watch(() => {
            getVaultById()
            getKeepByVaultId()
            vaultsService.clearAppState()
        })

        async function getVaultById() {
            try {
                const vaultId = route.params.vaultId
                await vaultsService.getVaultById(vaultId)

            } catch (error) {
                if (error.response.data.includes('go there')) {
                    Pop.error("You can't go there...");
                    router.push({ name: 'Home' })
                }
            }
        }

        async function getKeepByVaultId() {
            try {
                const vaultId = route.params.vaultId
                keepsService.getKeepByVaultId(vaultId)

            } catch (error) {
                Pop.error(error)
            }
        }



        return {
            activeVault: computed(() => AppState.activeVault),
            keepsInVaults: computed(() => AppState.keepsInVault),
            coverImg: computed(() => `url(${AppState.activeVault?.img})`),
            keepImg: computed(() => `url(${AppState.keepsInVault?.img})`),
            account: computed(() => AppState.account),

            async destroyKeepFromVault(vaultKeepId) {
                try {
                    const wantsToDelete = await Pop.confirm("You sure you want to delete this keep out of your vault?")
                    if (!wantsToDelete) {
                        return
                    }
                    await keepsService.destroyKeepFromVault(vaultKeepId)
                } catch (error) {
                    Pop.error(error)
                }
            }
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

.bg-keep {
    background-image: v-bind(keepImg);
    background-position: center;
    background-size: cover;
    height: 20vh;
}

.text-shadow {
    text-shadow: 1px 1px 2px black;
}
</style>