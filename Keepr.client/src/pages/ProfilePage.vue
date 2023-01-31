<template>
  <div v-if="profile" class="container p-4">
    <section class="row justify-content-center accountcover rounded"
      :style="{ backgroundImage: `url('${profile.coverImg}')` }">
    </section>
    <section class="row">
      <section class="col-12 text-center">
        <section class="row"></section>
        <img :src="profile.picture" alt="" class="accountpic moveUp rounded-circle elevation-5 border border-white">
        <h1 class=" moveUp  text-shadow">{{ profile.name }}</h1>
        <p class="moveUp" v-if="vaults && keeps">{{ vaults.length }} Vaults | {{ keeps.length }} Keeps</p>
      </section>
    </section>
    <section class="row ps-5 mt-5 text-shadow">
      <h1>Vaults</h1>
    </section>
    <section v-if="vaults" class="row">
      <section v-for="v in vaults" class="col-3">
        <VaultComponent :vault="v" />
      </section>
    </section>
    <section class="row p-5  text-shadow">
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
import { useRoute } from "vue-router";
import { profilesService } from "../services/ProfilesService.js";

export default {
  setup() {
    const route = useRoute()
    async function getProfile() {
      try {
        profilesService.getProfile(route.params.id);
      } catch (error) {
        Pop.error(error);
        logger.log(error);
      }
    }

    async function getProfileVaults() {
      try {
        profilesService.getProfileVaults(route.params.id);
      } catch (error) {
        Pop.error(error);
        logger.log(error);
      }
    }

    async function getProfileKeeps() {
      try {
        profilesService.getProfileKeeps(route.params.id);
      } catch (error) {
        Pop.error(error);
        logger.log(error);
      }
    }

    onMounted(() => {
      getProfile()
      getProfileVaults()
      getProfileKeeps()
    })
    return {
      route,
      profile: computed(() => AppState.profile),
      vaults: computed(() => AppState.profileVaults),
      keeps: computed(() => AppState.profileKeeps)
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

.text-shadow {
    text-shadow: 2px 2px 4px #484848;
}
</style>

