<template>
  <section class="row m-1 main elevation-3 rounded" :style="{ backgroundImage: `url('${keep.img}')` }">
    <div @click="setActiveKeep(keep.id)" id="name" class=" selectable d-flex justify-content-between align-items-end"
      data-bs-toggle="modal" data-bs-target="#KeepModal">
      <p class="m-0 fw-bold fs-5">
        {{ keep.name }}
      </p>
      <img class="rounded-circle mb-2" :src="keep.creator.picture" alt="" :title="keep.creator.name">
    </div>
  </section>

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { keepsService } from "../services/KeepsService.js";
export default {
  props: ({
    keep: { type: Object, required: true }
  }),
  setup() {

    return {
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