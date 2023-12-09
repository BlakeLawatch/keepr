import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"
import Pop from '../utils/Pop';

class KeepsService {

    async getKeeps() {
        const res = await api.get(`api/keeps`)
        AppState.keeps = res.data.map(pojo => new Keep(pojo))
        logger.log('got keeps FINISH IN THE SERVICE', AppState.keeps)
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
        const res = api.delete(`api/keeps/${keepId}`)
        const index = AppState.keeps.findIndex(keep => keep.id == keepId)
        AppState.keeps.splice(index, 1)
        AppState.activeKeep = null
        logger.log('Deleted keep FINISH IN THE SERVICE', res.data)

    }
}

export const keepsService = new KeepsService()