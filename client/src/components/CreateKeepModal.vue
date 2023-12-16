<template>
    <div class="modal fade" id="createKeep" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="text-center">
                    <h1 class="text-center text-info info-text-shadow">keep</h1>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="createKeep()">
                        <div class="mb-3">
                            <label for="name" class="form-label">Name</label>
                            <input v-model="editable.name" type="text" class="form-control" id="name" maxlength="35"
                                required>
                        </div>
                        <div class="mb-3">
                            <label for="Image URL" class="form-label">Image URL</label>
                            <input v-model="editable.img" type="url" class="form-control" id="Image URL" maxlength="1000"
                                required>
                        </div>
                        <div class="mb-3">
                            <label for="description" class="form-label">Description</label>
                            <input v-model="editable.description" type="text" class="form-control" id="description" required
                                maxlength="500">
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
import { keepsService } from '../services/KeepsService';
import { Modal } from 'bootstrap';
import Pop from '../utils/Pop';


export default {
    setup() {
        const editable = ref({})
        return {
            editable,

            async createKeep() {
                try {
                    const keepData = editable.value
                    await keepsService.createKeep(keepData)
                    editable.value = {}
                    Modal.getOrCreateInstance('#createKeep').hide()

                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>