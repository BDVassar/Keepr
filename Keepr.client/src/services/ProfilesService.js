import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class ProfilesService {
  async getProfile(profileId) {
    const res = await api.get("api/profiles/" + profileId);
    // logger.log("[Getting Profile]", res.data);
    AppState.profile = res.data;
  }

  async getProfileVaults(profileId) {
    const res = await api.get("api/profiles/" + profileId + "/vaults");
    // logger.log("[Getting Vaults]", res.data);
    AppState.profileVaults = res.data;
  }
  async getProfileKeeps(profileId) {
    const res = await api.get("api/profiles/" + profileId + "/keeps");
    // logger.log("[Getting Keeps]", res.data);
    AppState.profileKeeps = res.data;
  }
}

export const profilesService = new ProfilesService();