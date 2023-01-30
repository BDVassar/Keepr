import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class KeepService {


  async getKeeps() {
    const res = await api.get("api/keeps");
    // logger.log("[Getting Keeps]", res.data)
    AppState.keeps = res.data;
  }

  async getProfileKeeps() {
    const res = await api.get("api/profile/" + AppState.account.id + "/keeps")
    logger.log("[Getting Profile Keeps", res.data)
  }

  async setActiveKeep(keepId) {
    const res = await api.get("api/keeps/" + keepId);
    // logger.log("[SettingActiveKeep]", res.data);
    AppState.activeKeep = res.data;
    logger.log(AppState.activeKeep)
  }
}

export const keepsService = new KeepService();