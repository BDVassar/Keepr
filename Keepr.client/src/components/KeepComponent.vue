<template>
  <section @click="setActiveKeep(keep.id)" class="row m-1 main elevation-3 rounded  justify-content-between selectable"
    :style="{ backgroundImage: `url('${keep.img}')` }">
    <div v-if="keep.vaultKeepId && keep.creatorId == vault.creatorId" class="d-flex justify-content-between">
      <div class="col-7">
        <button @click.stop="removeVaultKeep(keep.vaultKeepId)"
          class="text-shadow fs-5 btn mdi mdi-circle-off-outline text-light" title="remove from vault"
          aria-label="remove from vault">
          Remove</button>
      </div>
      <section class="col-3 text-end">
        <button @click.stop="removeKeep(keep.id)" v-if="account.id == keep.creatorId"
          class="text-shadow fs-4 btn btn--outline text-danger mdi mdi-delete" aria-label="delete"
          title="delete"></button>
      </section>
    </div>
    <div v-else>
      <section class="col-12 text-end">
        <button @click.stop="removeKeep(keep.id)" v-if="account.id == keep.creatorId"
          class="text-shadow fs-4 btn btn--outline text-danger mdi mdi-delete" title="delete"
          aria-label="delete"></button>
      </section>
    </div>
    <section class="col-8 col-md-9 d-flex align-items-end">
      <p class="m-0 fw-bold fs-5 text-shadow">
        {{ keep.name }}
      </p>
    </section>
    <section v-if="account.id == keep.creatorId" class="col-4 col-md-3 d-flex align-items-end">
      <img id="creator" @click.stop="router.push({ name: 'Account' })" :src="keep.creator.picture" alt=""
        class="rounded-circle mb-2" :title="keep.creator.name" :aria-label="keep.creator.name">
    </section>
    <section v-else class="col-4 col-md-3 d-flex align-items-end">
      <img id="creator" @click.stop="router.push({ name: 'Profile', params: { id: keep.creator.id } })"
        :src="keep.creator.picture" alt="" class="rounded-circle mb-2" :title="keep.creator.name"
        :aria-label="keep.creator.name">
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
      vault: computed(() => AppState.activeVault),
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
          const confirm = await Pop.confirm("Are you sure you want to remove this Keep?")
          if (!confirm) { return }
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

  img {
    height: 50px;
    width: 50px;
    size: fill;
  }
}

@media (max-width: 768px) {
  #creator {
    transform: translateX(-20px);
  }
}

.text-shadow {
  text-shadow: 2px 2px 4px #484848;
}
</style>