<template>
  <form @submit.prevent="editAccount()">
    <section class="row justify-content-end pe-2 pt-1">
      <div class="col-1">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="col-12 p-3 ps-5">
        <h5>Edit Your Account</h5>
      </div>
    </section>
    <section class="row justify-content-center">

      <div class=" col-7 form-floating mb-3">
        <input maxlength="40" v-model="accountInfo.name" type="text" class="form-control-plaintext border-bottom"
          id="name" placeholder="name">
        <label for="name">Name...</label>
      </div>
      <div class="col-7 form-floating mb-3">
        <input maxlength="240" v-model="accountInfo.picture" type="text" class="form-control-plaintext border-bottom"
          id="picture" placeholder="picture">
        <label for="picture">Picture...</label>
      </div>
      <div class="col-7 form-floating mb-3">
        <input maxlength="240" v-model="accountInfo.coverImg" type="text" class="form-control-plaintext border-bottom"
          id="coverImg" placeholder="coverImg">
        <label for="coverImg">Cover Image...</label>
      </div>
    </section>
    <section class="row justify-content-end p-4">
      <div class="col-2">
        <button type="submit" class="btn btn-success
  " data-bs-dismiss="modal">Edit</button>
      </div>
    </section>
  </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { accountService } from "../services/AccountService.js";
export default {
  setup() {
    const accountInfo = ref({})
    return {
      accountInfo,

      async editAccount() {
        try {
          accountService.editAccount(accountInfo.value)
        } catch (error) {
          Pop.error(error)
          logger.log(error)
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>

</style>