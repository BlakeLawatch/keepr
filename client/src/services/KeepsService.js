import { AppState } from "../AppState"
import { Keep } from "../models/Keep"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class KeepsService {

    async getKeeps() {
        const res = await api.get(`api/keeps`)
        AppState.keeps = res.data.map(pojo => new Keep(pojo))
        logger.log('got keeps FINISH IN THE SERVICE', AppState.keeps)
    }

    setActiveKeep(keep) {
        AppState.activeKeep = keep
    }
}

export const keepsService = new KeepsService()