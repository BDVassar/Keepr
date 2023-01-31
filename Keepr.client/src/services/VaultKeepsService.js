import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultKeepsService {
  async CreateVaultKeep(vaultKeepData) {
    const res = await api.post("api/vaultkeeps", vaultKeepData)
    logger.log("[created vaultkeep relationship]", res.data)
  }

  async removeVaultKeep(vaultKeepId) {
    const res = await api.delete("api/vaultkeeps/" + vaultKeepId);
    logger.log("[deleted vaultkeep relationship]", res.data);
    let index = AppState.activeVaultsKeeps.findIndex((k) => k.id == vaultKeepId);
    AppState.activeVaultsKeeps.splice(index, 1);
  }
}

export const vaultKeepsService = new VaultKeepsService()