<template>
  <form @submit="createKeep()">
    <section class="row justify-content-end pe-2 pt-1">
      <div class="col-1">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="col-12 p-3 ps-5">
        <h5>Add your keep</h5>
      </div>
    </section>
    <section class="row justify-content-center">

      <div class=" col-7 form-floating mb-3">
        <input v-model="keepData.name" type="text" class="form-control-plaintext border-bottom" id="name"
          placeholder="name">
        <label for="keepName">Title...</label>
      </div>
      <div class="col-7 form-floating mb-3">
        <input v-model="keepData.img" type="text" class="form-control-plaintext border-bottom" id="img"
          placeholder="img">
        <label for="img">Image URL...</label>
      </div>
      <div class="col-7 form-floating mb-3">
        <textarea v-model="keepData.description" type="text" class="form-control-plaintext border-bottom"
          id="description" placeholder="description"></textarea>
        <label for="description">Description...</label>
      </div>
    </section>
    <section class="row justify-content-end p-4">
      <div class="col-2">
        <button type="submit" class="btn btn-success
        " data-bs-dismiss="modal">create</button>
      </div>
    </section>
  </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { keepsService } from "../services/KeepsService.js";
export default {
  setup() {
    const keepData = new ref({})
    return {
      keepData,

      async createKeep() {
        try {
          await keepsService.createKeep({ ...keepData.value })
        } catch (error) {
          Pop.error(error);
          logger.error(error);
        }
      }
    }
  }
};
</script>


<style lang="scss" scoped>

</style>