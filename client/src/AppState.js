import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},

  /** @type {import('./models/Keep.js').Keep []} */
  keeps: [],
  /** @type {import('./models/Keep.js').Keep | null} */
  activeKeep: null,
  /** @type {import('./models/Vault.js').Vault []} */
  vaults: [],
  /** @type {import('./models/Vault.js').Vault []} */
  vaultKeeps: [],
  /** @type {import('./models/Vault.js').Vault | null} */
  activeVault: null,
  /** @type {import('./models/Vault.js').Vault []} */
  accountVaults: [],
  /** @type {import('./models/ProfileVault.js').ProfileVault []} */
  profileVaults: [],
  /** @type {import('./models/Profile.js').Profile | null} */
  profiles: null,
  /** @type {import('./models/ProfileKeep.js').ProfileKeep []} */
  profileKeeps: [],
  /** @type {import('./models/KeepsInVault.js').KeepsInVault []} */
  keepsInVault: []
})
