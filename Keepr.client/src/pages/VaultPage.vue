<template>
  <div v-if="vault" class="container p-4">
    <section class="row justify-content-center accountcover rounded"
      :style="{ backgroundImage: `url('${vault.img}')` }">
    </section>
    <section class="row justify-content-center">
      <section class="col-2 text-center">
        <h5 class="mt-4 bg-grey rounded-pill p-2" v-if="keeps">{{ keeps.length }} Keeps</h5>
      </section>
    </section>

    <section v-if="keeps" class="masonry">
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
import { useRoute } from "vue-router";
import { vaultsService } from "../services/VaultsService.js";

export default {
  setup() {
    const route = useRoute()

    async function GetVault() {
      try {
        await vaultsService.GetVault(route.params.id);
      } catch (error) {
        Pop.error(error);
        logger.error(error);
      }
    }
    async function GetVaultsKeeps() {
      try {
        await vaultsService.GetVaultsKeeps(route.params.id);
      } catch (error) {
        Pop.error(error);
        logger.error(error);
      }
    }

    onMounted(() => {
      GetVault();
      GetVaultsKeeps();
    })
    return {
      route,
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.activeVaultsKeeps),

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

.accountpic {
  height: 250px;
  width: 250px;
}

.moveUp {
  transform: translateY(-120px);
}

.accountcover {
  background-position: center;
  background-size: cover;
  height: 500px;
}
</style>