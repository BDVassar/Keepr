<template>
  <section @click="setActiveKeep(keep.id)" id="name"
    class="row m-1 main elevation-3 rounded  justify-content-between align-items-end selectable"
    :style="{ backgroundImage: `url('${keep.img}')` }" data-bs-toggle="modal" data-bs-target="#KeepModal">
    <div class="col-9">
      <p class="m-0 fw-bold fs-5">
        {{ keep.name }}
      </p>
    </div>
    <div class="col-3">
      <img @click.stop="router.push({ name: 'Profile', params: { id: keep.creator.id } })" :src="keep.creator.picture"
        alt="" class="rounded-circle mb-2">
    </div>
  </section>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { keepsService } from "../services/KeepsService.js";
import { router } from "../router.js";
export default {
  props: ({
    keep: { type: Object, required: true }

  }),
  setup() {
    router
    return {
      router,
      async setActiveKeep(keepId) {
        try {
          await keepsService.setActiveKeep(keepId);
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