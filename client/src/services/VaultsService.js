import { AppState } from "../AppState"
import { Vault } from "../models/Vault"
import { api } from "./AxiosService"

class VaultsService {

    async createVault(vaultData) {
        const res = await api.post(`api/vaults`, vaultData)
        AppState.vaults.push(new Vault(res.data))
        logger.log(`createdVault FINISH IN THE SERVICE`, AppState.vaults)
    }

}

export const vaultsService = new VaultsService()