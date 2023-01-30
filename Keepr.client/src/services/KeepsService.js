import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class KeepService {


  async getKeeps() {
    const res = await api.get("api/keeps");
    // logger.log("[Getting Keeps]", res.data)
    AppState.keeps = res.data;
  }

  async setActiveKeep(keepId) {
    const res = await api.get("api/keeps/" + keepId);
    // logger.log("[SettingActiveKeep]", res.data);
    AppState.activeKeep = res.data;
    logger.log(AppState.activeKeep)
  }

  async getMyKeeps() {
    AppState.myKeeps = AppState.keeps.filter((k) => k.creatorId == AppState.account.id)
    logger.log("[My Keeps]", AppState.myKeeps)
  }
}

export const keepsService = new KeepService();