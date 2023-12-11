import { RepoItem } from "./RepoItem";

export class ProfileVault extends RepoItem {
    constructor(data) {
        super(data)
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.isPrivate = data.isPrivate
        this.creator = data.creator
        this.creatorId = data.creatorId

    }
}

const data = {
    "name": "Kinda Regular",
    "description": "A Board to save all the things I love",
    "img": "https://images.unsplash.com/photo-1580597095981-8d21aa8cdfed?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=500&h=400&q=60",
    "isPrivate": false,
    "creatorId": "65383a6f85a44e46777ed7d1",
    "creator": {
        "name": "heyitsme@its.me",
        "picture": "https://s.gravatar.com/avatar/469c061e9ec48a562bcbde38deafd05e?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fhe.png",
        "coverImg": null,
        "id": "65383a6f85a44e46777ed7d1",
        "createdAt": "2023-12-08T19:02:35",
        "updatedAt": "2023-12-08T19:02:35"
    },
    "id": 12,
    "createdAt": "2023-12-10T17:49:07",
    "updatedAt": "2023-12-10T17:49:07"
}