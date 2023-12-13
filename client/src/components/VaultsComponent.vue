<template>
    <div class="bg-img col-12 my-2 box-shadow">
        <div class="text-end">
            <button @click="destroyVault(vault.id)" class="btn btn-danger rounded-circle fs-6"><i
                    class="mdi mdi-close"></i></button>
        </div>
        <div class="d-flex align-items-end justify-content-around">
            <router-link :to="{ name: 'Vault', params: { vaultId: vault.id } }">
                <h3 class="selectable text-shadow text-light" :title="vault.name">{{ vault.name }}</h3>
            </router-link>
            <p class="mb-0 fs-2 text-light text-shadow" v-if="vault.isPrivate"><i class="mdi mdi-lock-outline"></i></p>

        </div>
    </div>
</template>


<script>
import { computed } from 'vue';
import { Vault } from '../models/Vault';
import { AppState } from '../AppState';
import Pop from '../utils/Pop';
import { vaultsService } from '../services/VaultsService';


export default {
    props: {
        vault: { type: Vault, required: true }
    },
    setup(props) {
        return {
            coverImg: computed(() => `url(${props.vault.img})`),
            account: computed(() => AppState.account),

            async destroyVault(vaultId) {
                try {
                    const wantsToDelete = await Pop.confirm('You want to delete your vault?')
                    if (!wantsToDelete) {
                        return
                    }
                    await vaultsService.destroyVault(vaultId)
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

.text-shadow {
    text-shadow: 1px 1px 2px rgb(3, 3, 3);
}

.box-shadow {
    box-shadow: 2px 2px 10px gray;
}
</style>