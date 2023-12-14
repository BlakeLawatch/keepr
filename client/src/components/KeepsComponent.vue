<template>
    <div @click="setActiveKeep()" class="selectable box-shadow bg-img align-items-between my-3" :title="keep.name">
        <div class="text-end">
            <button v-if="keep.creatorId == account.id" @click.stop="destroyKeep(keep.id)"
                class="btn btn-danger rounded-circle font"><i class="mdi mdi-close" title="Delete this Keep"></i></button>
        </div>
        <div class=" my-3 d-flex justify-content-between p-2">
            <p class="mb-0 text-shadow text-light d-flex fs-3 fw-bold text-break"> {{ keep.name }}</p>
            <router-link @click.stop :to="{ name: 'Profile', params: { profileId: keep.creatorId } }">
                <img class="img-fluid profile" :src="keep.creator.picture" alt="Creator Profile" :title="keep.creator.name">

            </router-link>
        </div>
    </div>
</template>
data-bs-toggle="modal" data-bs-target="#keepModal"


<script>
import { computed } from 'vue';
import { Keep } from '../models/Keep';
import { keepsService } from '../services/KeepsService';
import { Modal } from 'bootstrap';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';




export default {
    props: {
        keep: { type: Keep, required: true }
    },
    setup(props) {

        return {
            coverImg: computed(() => `url(${props.keep.img})`),
            account: computed(() => AppState.account),


            setActiveKeep() {
                keepsService.setActiveKeep(props.keep)
                Modal.getOrCreateInstance('#keepModal').show()
            },


            async destroyKeep(keepId) {
                try {
                    keepsService.destroyKeep(keepId)
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