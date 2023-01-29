<template>
  <div class="container p-4">
    <section class="masonry">
      <div v-for="k in keeps" class="">
        <KeepComponent :keep="k" />
      </div>
    </section>
  </div>
</template>

<script>
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { keepsService } from "../services/KeepsService.js"
import { onMounted, computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {

    async function getKeeps() {
      try {
        keepsService.getKeeps();
      } catch (error) {
        Pop.error(error)
        logger.log(error)
      }
    }

    onMounted(() => {
      getKeeps();
    })
    return {
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">
.masonry {
  columns: 4 200px;
  column-gap: 1rem;

  div {
    width: 150px;
    margin: 0 1rem 1rem 0;
    display: inline-blockblo;
    width: 100%;
  }

  @for $i from 1 through 1000 {
    div:nth-child(#{$i}) {
      $h: (random(400) + 200)+px;
      height: $h;
      line-height: $h;
    }
  }
}
</style>
