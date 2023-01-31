<template>
  <router-link :to="{ name: 'Vault', params: { id: vault.id } }">

    <section class="row m-1 main elevation-3 rounded" :style="{ backgroundImage: `url('${vault.img}')` }">
      <section class="col-12 text-end">
        <button @click.stop="removeVault(vault.id)" v-if="account.id == vault.creatorId"
          class="btn btn--outline text-danger mdi mdi-delete"></button>
      </section>
      <section id="name" class="col-12 selectable d-flex justify-content-between align-items-end">
        <section>

          <p class="m-0 fw-bold fs-5 col-6 text-light">
            {{ vault.name }}
          </p>
        </section>
        <section>
          <p v-if="vault.isPrivate" class="m-0 fw-bold fs-5 col-6 text-light mdi mdi-lock"></p>
        </section>

      </section>
    </section>

  </router-link>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { vaultsService } from "../services/VaultsService.js";
export default {
  props: ({
    vault: { type: Object, required: true }
  }),
  setup() {

    return {
      account: computed(() => AppState.account),

      async removeVault(vaultId) {
        try {
          await vaultsService.removeVault(vaultId);
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
  height: 200px;
}

#name {
  img {
    height: 50px;
    width: 50px;
    size: fill;
  }
}
</style>