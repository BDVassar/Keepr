import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class KeepService {


  async getKeeps() {
    const res = await api.get("api/keeps");
    logger.log("[Getting Keeps]", res.data)
    AppState.keeps = res.data;
  }
}

export const keepsService = new KeepService();