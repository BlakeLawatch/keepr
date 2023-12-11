import { AppState } from "../AppState"
import { Vault } from "../models/Vault"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import Pop from '../utils/Pop';

class VaultsService {

    async createVault(vaultData) {
        const res = await api.post(`api/vaults`, vaultData)
        AppState.vaults.push(new Vault(res.data))
        logger.log(`createdVault FINISH IN THE SERVICE`, AppState.vaults)
    }

    async destroyVault(vaultId) {
        const res = await api.delete(`api/vaults/${vaultId}`)
        const index = AppState.vaults.findIndex(vault => vault.id == vaultId)
        AppState.vaults.splice(index, 1)
        logger.log('deleted vault FINISH IN THE SERVICE', res.data)
    }

}

export const vaultsService = new VaultsService()