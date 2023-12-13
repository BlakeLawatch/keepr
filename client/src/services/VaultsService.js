import { AppState } from "../AppState"
import { Vault } from "../models/Vault"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import Pop from '../utils/Pop';
import { VaultKeep } from "../models/VaultKeep";
import { Keep } from "../models/Keep";

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

    async getVaultById(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}`)
        AppState.activeVault = new Vault(res.data)
        logger.log('got vault by ID FINISH IN THE SERVICE', res.data)
    }

    async createVaultKeep(vaultKeepData) {
        const res = await api.post(`api/vaultkeeps`, vaultKeepData)
        AppState.activeKeep.kept++
        AppState.activeKeep.push(new Keep(res.data))
        logger.log('created vaultKeep FINISH IN THE SERVICE', res.data)
    }



    clearAppState() {
        AppState.activeVault = null
        AppState.keepsInVault = null
    }

}

export const vaultsService = new VaultsService()