<template>
  <div v-if="keep">
    <div class="modal-body container p-0">
      <section class="row">
        <div class="col-6 d-flex">
          <img :src="keep.img" alt="" class="img-fluid rounded-start">
        </div>
        <div class="col-6 d-flex">
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
                <div class="col-4 f-flex flex-row">
                  <button class="btn dropdown-toggle order-lg-2" type="button" data-bs-toggle="dropdown"
                    aria-expanded="false">
                    Plants
                  </button>
                  <ul class="dropdown-menu">
                    <li><a class="dropdown-item" href="#">New Keep</a></li>
                    <li><a class="dropdown-item" href="#">New Vault</a></li>
                  </ul>
                  <button class="btn btn-primary">save</button>
                </div>
                <div class="col-1 pb-2 pe-5">
                  <router-link :to="{ name: 'Profile' }">
                    <img :src="keep.creator.picture" alt="" class="rounded-circle creatorimg" data-bs-dismiss="modal">
                  </router-link>
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
import { computed, reactive, onMounted } from 'vue';
export default {
  setup() {
    return {
      keep: computed(() => AppState.activeKeep)
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