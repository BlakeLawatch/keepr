<template>
    <div class="component">
        this is the profile page
    </div>
</template>


<script>

import { watch } from 'vue';
import { profilesService } from '../services/ProfilesService.js'
import Pop from '../utils/Pop';
import { useRoute } from 'vue-router';



export default {
    setup() {
        const route = useRoute()
        watch(() => {
            getProfiles()
        })

        async function getProfiles() {
            try {
                const profileId = route.params.profileId
                await profilesService.getProfiles(profileId)
            } catch (error) {
                Pop.error(error)
            }
        }
        return {


        }
    }
};
</script>


<style lang="scss" scoped></style>