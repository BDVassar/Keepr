import { AppState } from "../AppState.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService {

  async GetVault(vaultId) {
    const res = await api.get("api/vaults/" + vaultId);
    // logger.log("[Getting Active Vault]", res.data);
    AppState.activeVault = res.data;
  }

  async GetVaultsKeeps(vaultId) {
    const res = await api.get("api/vaults/" + vaultId + "/keeps");
    logger.log("[Getting Active Vault Keeps]", res.data);
    AppState.activeVaultsKeeps = res.data;
  }

  async CreateVault(vaultData) {
    const res = await api.post("api/vaults", vaultData);
    logger.log("[Creating Vault]", res.data);
    AppState.myVaults.push(res.data);
  }

  async removeVault(vaultId) {
    const res = await api.delete("api/vaults/" + vaultId);
    logger.log(res.data)
    let index = AppState.myVaults.findIndex((v) => v.id == vaultId);
    AppState.myVaults.splice(index, 1)
  }
}

export const vaultsService = new VaultsService()