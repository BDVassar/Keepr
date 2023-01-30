<template>
  <section class="row m-1 main elevation-3 rounded" :style="{ backgroundImage: `url('${vault.img}')` }">
    <section id="name" class=" selectable d-flex justify-content-between align-items-end">
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

</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { keepsService } from "../services/KeepsService.js";
export default {
  props: ({
    vault: { type: Object, required: true }
  }),
  setup() {

    return {

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