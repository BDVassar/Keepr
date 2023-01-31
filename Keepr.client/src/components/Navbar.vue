<template>
  <div class="container-fluid elevation-2">
    <section class="row justify-content-between">
      <div class=" order-2 order-md-1 col-2 d-flex">
        <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
          <button class="btn d-md-block d-none"> Home</button>
        </router-link>
        <button class=" btn dropdown-toggle" type="button" data-bs-toggle="dropdown" aria-expanded="false">
          Create
        </button>
        <ul class="dropdown-menu">
          <li @click.prevent="openKeepModal()"><a class="dropdown-item" href="#">New Keep</a></li>
          <li @click.prevent="openVaultModal()"><a class="dropdown-item" href="#">New Vault</a></li>
        </ul>
      </div>
      <div class="order-1 logo col-2 p-3">
        <img src="../assets/img/Keepr logo.png" alt="">
      </div>
      <div class="order-3 col-1 d-flex justify-content-center align-items-center">
        <!-- LOGIN COMPONENT HERE -->
        <Login />
      </div>
    </section>
  </div>
</template>

<script>
import Login from './Login.vue'
import { Modal } from "bootstrap"
export default {
  setup() {
    return {
      openKeepModal() {
        Modal.getOrCreateInstance('#KeepForm').show();
      },
      openVaultModal() {
        Modal.getOrCreateInstance('#VaultForm').show();
      }
    }
  },
  components: { Login }
}
</script>

<style scoped>
img {
  height: 50px;
}
</style>
