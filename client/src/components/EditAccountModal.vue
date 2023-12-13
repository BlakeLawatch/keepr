<template>
    <div class="modal fade" id="editAccountModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="editAccount()">
                        <div class="mb-3">
                            <label for="name" class="form-label">Name</label>
                            <input v-model="editable.name" type="text" class="form-control" id="name" maxLength="255">
                        </div>
                        <div class="mb-3">
                            <label for="picture" class="form-label">Picture</label>
                            <input v-model="editable.picture" type="url" class="form-control" id="picture" maxlength="255">
                        </div>
                        <div class="mb-3">
                            <label for="coverImg" class="form-label">Cover Image</label>
                            <input v-model="editable.coverImg" type="url" class="form-control" id="coverImg"
                                maxlength="1000">
                        </div>
                        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="submit" class="btn btn-primary">Save changes</button>
                    </form>
                </div>


            </div>
        </div>
    </div>
</template>


<script>
import { ref } from 'vue';
import { AppState } from '../AppState';
import { accountService } from '../services/AccountService';
import { Modal } from 'bootstrap';


export default {
    setup() {
        const editable = ref({})


        return {
            editable,

            async editAccount() {
                const accountId = AppState.account.id
                const accountData = editable.value
                accountService.editAccount(accountId, accountData)
                editable.value = {}
                Modal.getOrCreateInstance('#editAccountModal').hide()

            }
        }
    }
};
</script>


<style lang="scss" scoped></style>