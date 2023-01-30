<template>
  <div class="container p-4">
    <section class="masonry">
      <div v-for="k in keeps" class="brick">
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
  column-gap: 12px;

}

.brick {
  width: 150px;
  margin: 0 10px 10px 0;
  width: 100%;
  color: antiquewhite;
  break-inside: avoid;
}

@for $index from 1 through 1000 {
  div:nth-child(#{$index}) {
    $h: (random(400) + 200)+px;
    height: $h;
  }
}
</style>
