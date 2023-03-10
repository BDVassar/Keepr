import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  keeps: null,
  activeKeep: null,
  myVaults: null,
  myKeeps: null,
  profile: null,
  profileKeeps: null,
  profileVaults: null,
  activeVault: null,
  activeVaultsKeeps: null,
})
