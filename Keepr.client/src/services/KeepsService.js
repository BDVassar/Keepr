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
    // logger.log(AppState.activeKeep)
  }

  async getMyKeeps() {
    const res = await api.get("api/keeps")
    // logger.log("[my keeps]", res.data)
    const mykeeps = res.data.filter((k) => k.creatorId == AppState.account.id);
    AppState.myKeeps = mykeeps;
    logger.log("[My Keeps]", AppState.myKeeps)
  }

  async createKeep(keepData) {
    const res = await api.post("api/keeps", keepData);
    logger.log("[Creating Keep]", res.data)
    AppState.keeps.push(res.data)
    AppState.myKeeps.push(res.data)
  }

  async removeKeep(keepId) {
    const res = await api.delete("api/keeps/" + keepId);
    logger.log("[Deleting Keep]", res.data);
    let index = AppState.keeps.findIndex((k) => k.id == keepId);
    AppState.keeps.splice(index, 1);
  }
}

export const keepsService = new KeepService();