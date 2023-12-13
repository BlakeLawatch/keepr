import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import Pop from '../utils/Pop';
import { Vault } from "../models/Vault";
import { VaultKeep } from "../models/VaultKeep";
import { KeepsInVault } from "../models/KeepsInVault";
import { Logger } from "sass";
import { profilesService } from "./ProfilesService";

class KeepsService {

    async getKeeps() {
        const res = await api.get(`api/keeps`)
        AppState.keeps = res.data.map(pojo => new Keep(pojo))
        // logger.log('got keeps FINISH IN THE SERVICE', AppState.keeps)
    }

    setActiveKeep(keep) {
        AppState.activeKeep = keep
    }

    async createKeep(keepData) {
        const res = await api.post(`api/keeps`, keepData)
        AppState.keeps.push(new Keep(res.data))
        // logger.log('created Keep FINISH IN THE SERVICE', res.data)
    }

    async destroyKeep(keepId) {
        const wantsToDelete = await Pop.confirm('You sure you want to delete this Keep?')
        if (!wantsToDelete) {
            return
        }
        const res = await api.delete(`api/keeps/${keepId}`)
        const index = AppState.keeps.findIndex(keep => keep.id == keepId)
        AppState.keeps.splice(index, 1)
        if (index == -1) {
            const profileIndex = AppState.profileKeeps.findIndex(profileKeep => profileKeep.id == keepId)
            AppState.profileKeeps.splice(profileIndex, 1)
        }
        AppState.activeKeep = null
        // logger.log('Deleted keep FINISH IN THE SERVICE', res.data)

    }

    async getKeepByVaultId(vaultId) {
        const res = await api.get(`api/vaults/${vaultId}/keeps`)
        AppState.keepsInVault = res.data.map(pojo => new KeepsInVault(pojo))
        logger.log('got keeps by vaultID FINISH IN THE SERVICE', res.data)
    }

    async destroyKeepFromVault(vaultKeepId) {
        const res = await api.delete(`api/vaultKeeps/${vaultKeepId}`)
        const index = AppState.keepsInVault.findIndex(vaultKeep => vaultKeep.id = vaultKeepId)
        AppState.keepsInVault.splice(index, 1)
        // logger.log('got keep out of vault', res.data)
    }

    async getKeepById(keepId) {
        const res = await api.get(`api/keeps/${keepId}`)
        logger.log(`got keep by ID`, res.data)
        AppState.activeKeep.views++
        AppState.activeKeep = new Keep(res.data)


        logger.log('Got keep by ID. FINISH IN THE SERVICE?', res.data)
    }



}

export const keepsService = new KeepsService()