<template>
  <section @click="setActiveKeep(keep.id)" id="name"
    class="row m-1 main elevation-3 rounded  justify-content-between selectable"
    :style="{ backgroundImage: `url('${keep.img}')` }">
    <div v-if="keep.vaultKeepId" class="d-flex justify-content-between">
      <div class="col-7">
        <button @click.stop="removeVaultKeep(keep.vaultKeepId)" class=" fs-5 btn mdi mdi-circle-off-outline text-light">
          Remove</button>
      </div>
      <section class="col-3 text-end">
        <button @click.stop="removeKeep(keep.id)" v-if="account.id == keep.creatorId"
          class="btn btn--outline text-danger mdi mdi-delete" name="delete"></button>
      </section>
    </div>
    <div v-else>
      <section class="col-12 text-end">
        <button @click.stop="removeKeep(keep.id)" v-if="account.id == keep.creatorId"
          class="btn btn--outline text-danger mdi mdi-delete"></button>
      </section>
    </div>
    <section class="col-8 col-md-9 d-flex align-items-end">
      <p class="m-0 fw-bold fs-5">
        {{ keep.name }}
      </p>
    </section>
    <section class="col-4 col-md-3 d-flex align-items-end">
      <img @click.stop="router.push({ name: 'Profile', params: { id: keep.creator.id } })" :src="keep.creator.picture"
        alt="" class="rounded-circle mb-2" :title="keep.creator.name">
    </section>
  </section>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { keepsService } from "../services/KeepsService.js";
import { router } from "../router.js";
import { Modal } from "bootstrap";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
export default {
  props: ({
    keep: { type: Object, required: true }
  }),
  setup() {
    router
    return {
      router,
      account: computed(() => AppState.account),
      async setActiveKeep(keepId) {
        try {
          await keepsService.setActiveKeep(keepId);
          Modal.getOrCreateInstance("#KeepModal").show();
        } catch (error) {
          Pop.error(error)
          logger.log(error)
        }
      },

      async removeKeep(keepId) {
        try {
          Modal.getOrCreateInstance("#KeepModal").hide();
          const confirm = await Pop.confirm("Are you sure you want to delete this Keep?")
          if (!confirm) { return }
          await keepsService.removeKeep(keepId);
        } catch (error) {
          Pop.error(error);
          logger.log(error);
        }
      },

      async removeVaultKeep(vaultKeepId) {
        try {
          await vaultKeepsService.removeVaultKeep(vaultKeepId);
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
.main {
  background-position: center;
  background-size: cover;
  height: inherit;
}

#name {

  img {
    height: 50px;
    width: 50px;
    size: fill;
  }
}
</style>