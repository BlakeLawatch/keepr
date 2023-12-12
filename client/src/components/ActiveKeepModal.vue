<template>
    <div v-if="activeKeep" class="modal fade" id="keepModal" tabindex="-1" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-body ps-0 py-0">
                    <div class="container-fluid ps-0 d-flex">
                        <section class="row">
                            <div class="col-12 col-md-6">
                                <img class="img-fluid" :src="activeKeep.img" alt="">
                            </div>
                            <div class="col-12 col-md-6">
                                <div class="d-flex justify-content-center">
                                    <p class="me-1">{{ activeKeep.views }} <i class="mdi mdi-eye"></i></p>
                                    <p class="ms-1">0 <i class="mdi mdi-pin"></i></p>
                                </div>
                                <div class="text-center">
                                    <h2>{{ activeKeep.name }}</h2>
                                    <p>{{ activeKeep.description }}</p>
                                </div>
                                <div class="d-flex align-items-center">
                                    <form @submit.prevent="createVaultKeep()">
                                        <div class="mb-3 text-start">
                                            <label for="vaultId" class="form-label"></label>
                                            <select v-model="editable.vaultId" id="vaultId" class="form-select">
                                                <option v-for="vault in vaults" :key="vault.id" :value="vault.id">
                                                    {{ vault.name }}
                                                </option>
                                            </select>
                                        </div>
                                        <button type="submit" class="btn btn-primary">Save</button>
                                    </form>
                                    <div class="d-flex">
                                        <router-link @click.stop
                                            :to="{ name: 'Profile', params: { profileId: activeKeep.creatorId } }">
                                            <img class="profile" :src="activeKeep.creator.picture" alt=""
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
import { Vault } from '../models/Vault';
import { vaultsService } from '../services/VaultsService';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
import { Modal } from 'bootstrap';


export default {

    setup() {
        const editable = ref({})

        return {
            editable,
            vaults: computed(() => AppState.vaults),
            activeKeep: computed(() => AppState.activeKeep),

            async createVaultKeep() {
                try {
                    const vaultKeepData = editable.value
                    vaultKeepData.keepId = AppState.activeKeep.id
                    logger.log('Vault ID is:', editable.value)

                    vaultsService.createVaultKeep(vaultKeepData)
                    Modal.getOrCreateInstance('#keepModal').hide()

                } catch (error) {
                    Pop.error(error)
                }
            }



        }
    }
};
</script>


<style lang="scss" scoped></style>