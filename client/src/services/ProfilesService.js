import { AppState } from "../AppState"
import { Profile } from "../models/Profile"
import { ProfileKeep } from "../models/ProfileKeep"
import { ProfileVault } from "../models/ProfileVault"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ProfilesService {

    async getProfiles(profileId) {
        const res = await api.get(`api/profiles/${profileId}`)
        AppState.profiles = new Profile(res.data)
        logger.log('got profiles FINISH IN THE SERVICE', AppState.profiles)
    }

    async getUsersKeeps(profileId) {
        const res = await api.get(`api/profiles/${profileId}/keeps`)
        AppState.profileKeeps = res.data.map(pojo => new ProfileKeep(pojo))
        // logger.log('got profiles keeps FINISH IN THE SERVICE', res.data)
    }

    async getUsersVaults(profileId) {
        const res = await api.get(`api/profiles/${profileId}/vaults`)
        AppState.profileVaults = res.data.map(pojo => new ProfileVault(pojo))
        logger.log('got vaults FINISH IN THE SERVICE', res.data)
    }
}

export const profilesService = new ProfilesService()