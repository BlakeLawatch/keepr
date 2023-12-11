import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ProfilesService {

    async getProfiles(profileId) {
        const res = await api.get(`api/profiles/${profileId}`)
        logger.log('got profiles FINISH IN THE SERVICE', res.data)
    }
}

export const profilesService = new ProfilesService()