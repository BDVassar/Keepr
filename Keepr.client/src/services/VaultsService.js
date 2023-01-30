import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async GetVault(vaultId) {
    const res = await api.get("api/vaults/" + vaultId)
    // logger.log("[Getting Active Vault]", res.data)
    AppState.activeVault = res.data;
  }

  async GetVaultsKeeps(vaultId) {
    const res = await api.get("api/vaults/" + vaultId + "/keeps")
    // logger.log("[Getting Active Vault Keeps]", res.data)
    AppState.activeVaultsKeeps = res.data;
  }
}

export const vaultsService = new VaultsService()