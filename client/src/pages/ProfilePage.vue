<template>
    <div v-if="profile" class="container">
        <section class="row justify-content-center">
            <div class="col-6 text-center">
                <img class="img-fluid height" :src="profile.coverImg" alt="">
                <img class="img-fluid height" :src="profile.picture" alt="">
                <p>{{ profile.name }}</p>

            </div>
        </section>
        <section class="row justify-content-center">
            <h1>Vaults</h1>
            <div v-for="profileVault in profileVaults" :key="profileVault.id"
                class="col-8 col-md-2 text-center bg-img-vaults">
                <img class="img-fluid" :src="profileVault.img" alt="">
                <router-link :to="{ name: 'Vault', params: { vaultId: profileVault.id } }">
                    {{ profileVault.name }}
                </router-link>
            </div>
        </section>
        <section class="row justify-content-center">
            <h1>Keeps</h1>
            <div v-for="keep in keeps" :key="keep.id" class="col-8 col-md-2 text-center">
                <div class="bg-img">
                    <img class="img-fluid" :src="keep.img" alt="">
                    {{ keep.name }}

                </div>
                <!-- <img class="img-fluid" :src="keep.img" alt=""> -->

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
            profileVaults: computed(() => AppState.profileVaults),
            coverImg: (() => `url(${AppState.profileKeeps?.img})`),
            coverImgVaults: (() => `url(${AppState.profileVaults?.img})`)
        };
    },
};
</script>


<style lang="scss" scoped>
.bg-img {
    background-image: v-bind(coverImg);
    background-position: center;
    background-size: cover;
    height: 20vh;
}

.bg-img-vaults {
    background-image: v-bind(coverImgVaults);
    background-position: center;
    background-size: cover;
    height: 20vh;
}

.height {
    max-height: 10vh;
}
</style>