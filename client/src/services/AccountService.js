import { AppState } from '../AppState'
import { Account } from '../models/Account.js'
import { Vault } from '../models/Vault'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async editAccount(accountId, accountData) {
    const res = await api.put(`account/${accountId}`, accountData)
    logger.log('edited account', res.data)
    AppState.account = new Account(res.data)
  }

  async getMyVaults() {
    const res = await api.get(`account/vaults`)
    AppState.vaults = res.data.map(pojo => new Vault(pojo))
    logger.log('got vaults FINISH IN THE SERVICE', AppState.vaults)
  }
}

export const accountService = new AccountService()
