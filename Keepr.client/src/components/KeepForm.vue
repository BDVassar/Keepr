<template>
  <form>
    <section class="row justify-content-end pe-2 pt-1">
      <div class="col-1">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="col-12 p-3 ps-5">
        <h5>Add your keep</h5>
      </div>
    </section>
    <section class="row justify-content-center">

      <div class=" col-7 form-floating mb-3">
        <input type="text" class="form-control-plaintext border-bottom" id="floatingEmptyPlaintextInput"
          placeholder="name@example.com">
        <label for="floatingEmptyPlaintextInput">Title...</label>
      </div>
      <div class="col-7 form-floating mb-3">
        <input type="text" class="form-control-plaintext border-bottom" id="floatingEmptyPlaintextInput"
          placeholder="name@example.com">
        <label for="floatingEmptyPlaintextInput">Image URL...</label>
      </div>
      <div class="col-7 form-floating mb-3">
        <input type="text" class="form-control-plaintext border-bottom" id="floatingEmptyPlaintextInput"
          placeholder="name@example.com">
        <label for="floatingEmptyPlaintextInput">Tags...</label>
      </div>
      <div class="col-7 form-floating mb-3">
        <textarea class="form-control border-" placeholder="Leave a comment here" id="floatingTextarea"></textarea>
        <label for="floatingTextarea">Keep Description...</label>
      </div>
    </section>
    <section class="row justify-content-end p-4">
      <div class="col-2">
        <button class="btn btn-success
        ">create</button>
      </div>
    </section>
  </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, reactive, onMounted } from 'vue';
export default {
  setup() {
    return {}
  }
};
</script>


<style lang="scss" scoped>

</style>