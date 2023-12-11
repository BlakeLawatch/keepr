<template>
    <div v-if="profile" class="container">
        <section class="row justify-content-center">
            <div class="col-6 text-center">
                <img :src="profile.coverImg" alt="">
                <img :src="profile.picture" alt="">
                <p>{{ profile.name }}</p>

            </div>
        </section>
        <section class="row justify-content-center">
            <h1>Vaults</h1>
            <div v-for="profileVault in profileVaults" :key="profileVault.id"
                class="col-8 col-md-2 text-center bg-img-vaults">
                <p>{{ profileVault.name }}</p>
            </div>
        </section>
        <section class="row justify-content-center">
            <h1>Keeps</h1>
            <div v-for="profileKeep in profileKeeps" :key="profileKeep.id" class="col-8 col-md-2 text-center bg-img">

                <p>{{ profileKeep.name }}</p>

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
        const route = useRoute()
        watch(() => {
            getProfiles()
            getUsersKeeps()
            getUsersVaults()
        })

        async function getProfiles() {
            try {
                const profileId = route.params.profileId
                await profilesService.getProfiles(profileId)
            } catch (error) {
                Pop.error(error)
            }
        }

        async function getUsersKeeps() {
            try {
                const profileId = route.params.profileId
                await profilesService.getUsersKeeps(profileId)
            } catch (error) {
                Pop.error(error)
            }
        }

        async function getUsersVaults() {
            try {
                const profileId = route.params.profileId
                await profilesService.getUsersVaults(profileId)
            } catch (error) {
                Pop.error(error)
            }
        }


        return {
            profile: computed(() => AppState.profiles),
            profileKeeps: computed(() => AppState.profileKeeps),
            profileVaults: computed(() => AppState.profileVaults),
            coverImg: (() => `url(${AppState.profileKeeps.picture})`),
            coverImgVaults: (() => `url(${AppState.profileVaults.img})`)


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

.bg-img-vaults {
    background-image: v-bind(coverImgVaults);
    background-position: center;
    background-size: cover;
    height: 20vh;
}
</style>