<template>
  <div v-if="keep">
    <div class="modal-body container p-0">
      <section class="row">
        <div class=" order-1 col-12  col-md-6 d-flex">
          <img :src="keep.img" alt="" class="img-fluid rounded-start">
        </div>
        <div class=" order-2 col-12 col-md-6 d-flex">
          <section class="row">
            <div class="col-12">
              <section class="row justify-content-center pt-5">
                <div class="col-3 mdi mdi-eye-outline text-end">{{ keep.views }}</div>
                <div class="col-3">
                  <img src="../assets/img/kept Logo.png" alt="">
                  {{ keep.kept }}
                </div>
              </section>
            </div>
            <div class="col-12 d-flex flex-column justify-content-center text-center">
              <h1>{{ keep.name }}</h1>
              <p class="px-5">{{ keep.description }}</p>
            </div>
            <div class="col-12 d-flex flex-column justify-content-end">
              <section class="row justify-content-between pe-4">
                <div class="col-7">
                  <div v-if="account == {}" class="input-group">
                    <select required v-model="relationship.vaultId" class="form-select" id="inputGroupSelect04"
                      aria-label="Example select with button addon">
                      <option selected>Choose...</option>
                      <option v-for="v in vaults" :value="v.id">{{ v.name }}</option>
                    </select>
                    <button @click="CreateVaultKeep(keep.id)" class="btn btn-primary" type="button">Button</button>
                  </div>
                </div>
                <div class="col-4 pb-2">
                  <section class="row flex-">
                    <div class="col-9 text-end d-flex align-items-center justify-content-end">
                      <router-link :to="{ name: 'Profile', params: { id: keep.creator.id } }">
                        <img :src="keep.creator.picture" alt="" class="rounded-circle creatorimg"
                          data-bs-dismiss="modal">
                      </router-link>
                    </div>
                    <div class="col-3 p-0 d-flex align-items-center">
                      <p class="m-0">{{ keep.creator.name }}</p>
                    </div>
                  </section>
                </div>
              </section>
            </div>
          </section>
        </div>
      </section>
    </div>
  </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted, ref } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { vaultKeepsService } from "../services/VaultKeepsService.js";
import { useRoute } from "vue-router";
import { Modal } from "bootstrap";
import { router } from "../router.js";
export default {
  setup() {
    const route = useRoute();
    router;
    const relationship = ref({});
    return {
      relationship,
      keep: computed(() => AppState.activeKeep),
      vaults: computed(() => AppState.myVaults),
      account: computed(() => AppState.account),

      async CreateVaultKeep(keepId) {
        try {
          await vaultKeepsService.CreateVaultKeep({
            ...relationship.value,
            keepId: keepId,
          })
          Modal.getOrCreateInstance("#KeepModal").hide();
          router.push({ name: 'Vault', params: { id: relationship.value.vaultId } })
        } catch (error) {
          Pop.error(error);
          logger.error(error);
        }
      },
    }
  }
};
</script>


<style lang="scss" scoped>
.creatorimg {
  height: 50px;
  width: 50px;
}
</style>