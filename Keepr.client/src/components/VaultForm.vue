<template>
  <form @submit="CreateVault()">
    <section class="row justify-content-end pe-2 pt-1">
      <div class="col-1">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="col-12 p-3 ps-5">
        <h5>Add your vault</h5>
      </div>
    </section>
    <section class="row justify-content-center">

      <div class=" col-7 form-floating mb-3">
        <input v-model="vaultData.name" type="text" class="form-control-plaintext border-bottom"
          id="floatingEmptyPlaintextInput" placeholder="name@example.com">
        <label for="floatingEmptyPlaintextInput">Title...</label>
      </div>
      <div class="col-7 form-floating mb-3">
        <input v-model="vaultData.img" type="text" class="form-control-plaintext border-bottom"
          id="floatingEmptyPlaintextInput" placeholder="name@example.com">
        <label for="floatingEmptyPlaintextInput">URL...</label>
      </div>
      <div class="col-7 form-floating mb-3">
        <textarea v-model="vaultData.description" type="text" class="form-control-plaintext border-bottom"
          id="floatingEmptyPlaintextInput" placeholder="name@example.com"></textarea>
        <label for="floatingEmptyPlaintextInput">Description...</label>
      </div>
    </section>
    <section class="row justify-content-end p-4">
      <div class="col-5">
        <p class="note m-0">Private Vaults can only be seen by you.</p>
        <div class="form-check">
          <input v-model="vaultData.isPrivate" class="form-check-input" type="checkbox" default="false"
            id="flexCheckDefault">
          <label class="form-check-label" for="flexCheckDefault">
            Make Vault Private?
          </label>
        </div>
        <button type="submit" class="btn btn-success
        " data-bs-dismiss="modal">Create Vault</button>
      </div>
    </section>
  </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { vaultsService } from "../services/VaultsService.js";
export default {
  setup() {
    const vaultData = new ref({})
    return {
      vaultData,
      async CreateVault() {
        try {
          await vaultsService.CreateVault(vaultData.value);
        } catch (error) {
          Pop.error(error);
          logger.log(error);
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>
.note {
  font-size: x-small;
}
</style>