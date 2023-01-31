<template>
  <div class="container p-4">
    <section class="row justify-content-center accountcover rounded"
      :style="{ backgroundImage: `url('${account.coverImg}')` }">
    </section>
    <section class="row">
      <section class="col-12 text-center">
        <section class="row"></section>
        <img :src="account.picture" alt="" class="accountpic moveUp rounded-circle elevation-5 border border-white">
        <h1 class=" moveUp">{{ account.name }}</h1>
        <p class="moveUp" v-if="myVaults && keeps">{{ myVaults.length }} Vaults | {{ keeps.length }} Keeps</p>
      </section>


    </section>
    <section class="row ps-5 mt-5">
      <h1>Vaults</h1>
    </section>
    <section v-if="myVaults" class="row">
      <section v-for="v in myVaults" class="col-3">
        <VaultComponent :vault="v" />
      </section>
    </section>
    <section class="row p-5">
      <h1>Keeps</h1>
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

export default {
  setup() {

    async function getMyVaults() {
      try {
        await accountService.getAccountVaults();
      } catch (error) {
        Pop.error(error)
        logger.log(error)
      }
    }

    async function getMyKeeps() {
      try {
        await keepsService.getMyKeeps();
      } catch (error) {
        Pop.error(error);
        logger.error(error);
      }
    }

    onMounted(() => {
      getMyVaults();
      getMyKeeps();
    })
    return {
      myVaults: computed(() => AppState.myVaults),
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.myKeeps)
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

