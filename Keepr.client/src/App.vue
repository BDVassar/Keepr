<template>
  <header class="order-md-1 order-2 nbar sticky-bottom bg-light">
    <Navbar />
  </header>
  <main class="order-md-2 order-1">
    <router-view />
  </main>
  <footer>
  </footer>
  <ModalComponent id="KeepModal">
    <KeepModal />
  </ModalComponent>
  <FormModalComponent id="KeepForm">
    <KeepForm />
  </FormModalComponent>
  <FormModalComponent id="VaultForm">
    <VaultForm />
  </FormModalComponent>
  <FormModalComponent id="AccountForm">
    <AccountForm />
  </FormModalComponent>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}

@media (max-width: 768px) {
  body {
    padding-bottom: calc(32px - 64px);
  }

  .nbar {
    width: 100%;
    position: fixed;
    bottom: 0;
    z-index: 10000;
  }
}
</style>
