<template>
    <div class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-body ps-0 py-0">
                    <div class="container-fluid ps-0 d-flex">
                        <section v-if="activeKeep" class="row">
                            <div class="col-12 col-md-6">
                                <img class="img-fluid h-100" :src="activeKeep.img" alt="">
                            </div>
                            <div class="col-12 col-md-6">
                                <div class="d-flex justify-content-center">
                                    <p title="Number of views for this Keep" class="me-2">{{ activeKeep.views }} <i
                                            class="mdi mdi-eye"></i></p>
                                    <p title="number of times this Keep has been kept" class="ms-2">{{ activeKeep.kept }} <i
                                            class="mdi mdi-pin"></i></p>
                                </div>
                                <div class="text-center">
                                    <h2>{{ activeKeep.name }}</h2>
                                    <p>{{ activeKeep.description }}</p>
                                </div>
                                <div class="d-flex justify-content-between">
                                    <div>
                                        <form v-if="account.id" @submit.prevent="createVaultKeep()">
                                            <div class="mb-3 text-start">
                                                <label for="vaultId" class="form-label"></label>
                                                <select v-model="editable.vaultId" id="vaultId" class="form-select">
                                                    <option v-for="vault in vaults" :key="vault.id" :value="vault.id">
                                                        {{ vault.name }}
                                                    </option>
                                                </select>
                                            </div>
                                            <button type="submit" class="btn btn-primary mb-1">Save</button>
                                        </form>

                                    </div>
                                    <div class="d-flex">
                                        <router-link @click.stop
                                            :to="{ name: 'Profile', params: { profileId: activeKeep.creatorId } }">
                                            <img class="profile me-2" :src="activeKeep.creator.picture" alt=""
                                                :title="activeKeep.creator.name">

                                        </router-link>
                                        <p class="mb-0">{{ activeKeep.creator.name }}</p>
                                    </div>
                                </div>
                            </div>

                        </section>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>


<script>
import { computed, ref } from 'vue';
import { AppState } from '../AppState';
import { vaultsService } from '../services/VaultsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { Modal } from 'bootstrap';



export default {

    setup() {
        const editable = ref({})



        return {
            editable,
            vaults: computed(() => AppState.accountVaults),
            activeKeep: computed(() => AppState.activeKeep),
            account: computed(() => AppState.account),

            async createVaultKeep() {
                try {
                    const vaultKeepData = editable.value
                    vaultKeepData.keepId = AppState.activeKeep.id
                    logger.log('Vault ID is:', editable.value)
                    Pop.success("Your keep has been kept")

                    await vaultsService.createVaultKeep(vaultKeepData)
                    Modal.getOrCreateInstance('#keepModal').hide()


                } catch (error) {
                    Pop.error(error)
                    // if (error.response.data.includes("Duplicate entry")) {
                    //     Pop.error("You already have that keep kept in that vault")
                    // }



                }
            },






        }
    }
};
</script>


<style lang="scss" scoped></style>