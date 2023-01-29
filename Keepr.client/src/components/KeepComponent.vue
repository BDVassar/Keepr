<template>
  <section class="row m-1 main elevation-3 rounded" :style="{ backgroundImage: `url('${keep.img}')` }">
    <div id="name" class="d-flex justify-content-between align-items-end">
      <p class="m-0 text-light">
        {{ keep.name }}
      </p>
      <img class="rounded-circle mb-2" :src="keep.creator.picture" alt="">
    </div>
    <div>
    </div>
  </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
  props: ({
    keep: { type: Object, required: true }
  }),
  setup() {
    return {}
  }
};
</script>


<style lang="scss" scoped>
.main {
  background-position: center;
  background-size: cover;
}

#name {

  img {
    height: 50px;
  }
}
</style>