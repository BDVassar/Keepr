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
import { accountService } from "../services/AccountService.js";

export default {
  setup() {

    async function getMyKeeps() {
      try {
        await keepsService.getProfileKeeps();
      } catch (error) {
        Pop.error(error)
        logger.log(error)
      }
    }

    onMounted(() => {
      getMyKeeps();
    })
    return {
      keeps: computed(() => AppState.keeps),
      account: computed(() => AppState.account)
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
}

@for $index from 1 through 1000 {
  div:nth-child(#{$index}) {
    $h: (random(400) + 200)+px;
    line-height: $h;
  }
}
</style>

