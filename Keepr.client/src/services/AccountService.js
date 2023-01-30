import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }
  async getAccountVaults() {
    const res = await api.get("/account/vaults")
    // logger.log("[Getting Account Vaults]", res.data)
    AppState.myVaults = res.data;
  }
}

export const accountService = new AccountService()
