<template>
  <form>
    <section class="row justify-content-end pe-2 pt-1">
      <div class="col-1">
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="col-12 p-3 ps-5">
        <h5>Add your vault</h5>
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
        <label for="floatingEmptyPlaintextInput">URL...</label>
      </div>
    </section>
    <section class="row justify-content-end p-4">
      <div class="col-5">
        <p class="note m-0">Private Vaults can only be seen by you.</p>
        <div class="form-check">
          <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault">
          <label class="form-check-label" for="flexCheckDefault">
            Make Vault Private?
          </label>
        </div>
        <button class="btn btn-success
        ">Create Vault</button>
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
.note {
  font-size: x-small;
}
</style>