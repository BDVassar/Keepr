<template>

  <section class="row m-1 main elevation-3 rounded selectable" :style="{ backgroundImage: `url('${vault.img}')` }">
    <section class="col-12 text-end removecol">
      <button @click.stop="removeVault(vault.id)" v-if="account.id == vault.creatorId"
        class="btn btn--outline text-danger mdi mdi-delete" aria-label="delete"></button>
    </section>
    <router-link class="d-flex" :to="{ name: 'Vault', params: { id: vault.id } }">
      <section id="name" class="col-12 detailscol d-flex justify-content-between align-items-end">
        <section>
          <p class="m-0 fw-bold fs-5 col-6 text-light p-0">
            {{ vault.name }}
          </p>
        </section>
        <section>
          <p v-if="vault.isPrivate" class="m-0 fw-bold fs-5 col-6 text-light mdi mdi-lock"></p>
        </section>

      </section>
    </router-link>
  </section>

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
          const confirm = await Pop.confirm("Are you sure you want to delete this Keep?")
          if (!confirm) { return }
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

  .removecol {
    height: 25px;
  }

  .detailscol {
    height: 180px;
    width: 100%;
  }
}

#name {
  img {
    height: 50px;
    width: 50px;
    size: fill;
  }
}
</style>