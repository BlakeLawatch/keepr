<template>
    <div class="modal fade" id="createVault" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                    <form @submit.prevent="createVault()">
                        <div class="mb-3">
                            <label for="name" class="form-label">Name</label>
                            <input v-model="editable.name" type="text" maxLength="50" class="form-control" required
                                id="name">
                        </div>
                        <div class="mb-3">
                            <label for="description" class="form-label">Description</label>
                            <input v-model="editable.description" type="text" maxLength="500" class="form-control" required
                                id="description">
                        </div>
                        <div class="mb-3">
                            <label for="img" class="form-label">Image</label>
                            <input v-model="editable.img" type="text" maxLength="500" class="form-control" required
                                id="img">
                        </div>
                        <div class="mb-3">
                            <label for="isPrivate" class="form-label">Private?</label>
                            <input v-model="editable.isPrivate" type="checkbox" class="rounded" id="isPrivate">
                        </div>
                        <div class="d-flex justify-content-between">
                            <button type="button" class="btn btn-outline-info" data-bs-dismiss="modal">Cancel</button>
                            <button type="submit" class="btn btn-info text-white">Save changes</button>
                        </div>
                    </form>
                </div>



            </div>
        </div>
    </div>
</template>


<script>
import { ref } from 'vue';
import { vaultsService } from '../services/VaultsService.js'
import { Modal } from 'bootstrap';
import Pop from '../utils/Pop';

export default {
    setup() {
        const editable = ref({})
        return {
            editable,

            async createVault() {
                try {
                    const vaultData = editable.value
                    await vaultsService.createVault(vaultData)
                    editable.value = {}
                    Modal.getOrCreateInstance('#createVault').hide()

                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>