<template>
    <div v-if="profile" class="container">
        <section class="row">
            <div class="relative">
                <img class="img-fluid rounded" :src="profile.coverImg" alt="">
                <div class="centered">
                    <img class="img-fluid rounded-circle picture" :src="profile.picture" alt="">
                </div>
            </div>
        </section>
        <section class="row mt-5">
            <h1>Vaults</h1>
            <div v-for="vault in vaults" :key="vault.id" class="col-6 col-md-3">
                <router-link :to="{ name: 'Vault', params: { vaultId: vault.id } }">
                    <VaultsComponent :vault="vault" />

                </router-link>
            </div>
        </section>
        <section class="row">
            <h1 class="my-5 my-2">Keeps</h1>
            <div v-for="keep in keeps" :key="keep.id" class="col-6 col-md-3">
                <KeepsComponent :keep="keep" />
            </div>
        </section>
    </div>
</template>
 


<script>

import { computed, watch } from 'vue';
import { profilesService } from '../services/ProfilesService.js'
import Pop from '../utils/Pop';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState.js'
import KeepsComponent from '../components/KeepsComponent.vue';
import VaultsComponent from '../components/VaultsComponent.vue';





export default {
    setup() {
        const route = useRoute();
        watch(() => {
            getProfiles();
            getUsersKeeps();
            getUsersVaults();
        });
        async function getProfiles() {
            try {
                const profileId = route.params.profileId;
                await profilesService.getProfiles(profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getUsersKeeps() {
            try {
                const profileId = route.params.profileId;
                await profilesService.getUsersKeeps(profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        async function getUsersVaults() {
            try {
                const profileId = route.params.profileId;
                await profilesService.getUsersVaults(profileId);
            }
            catch (error) {
                Pop.error(error);
            }
        }
        return {
            profile: computed(() => AppState.profiles),
            keeps: computed(() => AppState.profileKeeps),
            vaults: computed(() => AppState.profileVaults.filter(profileVaults => profileVaults.isPrivate == false)),
        };
    },
    components: { KeepsComponent, VaultsComponent }
};
</script>


<style lang="scss" scoped>
.centered {
    position: absolute;
    // top: 50%;
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