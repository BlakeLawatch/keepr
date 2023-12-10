import { RepoItem } from "./RepoItem";

export class Vault extends RepoItem {
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
    "name": "Blake",
    "description": "hello",
    "img": "https://images.unsplash.com/photo-1565299585323-38d6b0865b47?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8dGFjb3xlbnwwfHwwfHx8MA%3D%3D",
    "isPrivate": null,
    "creatorId": "6541827fc58db642d7c02476",
    "creator": {
        "name": "anothernewemail@new.email",
        "picture": "https://s.gravatar.com/avatar/87d93fa56cfb84f69fde33613bc552ea?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fan.png",
        "id": "6541827fc58db642d7c02476",
        "createdAt": "2023-12-08T19:01:24",
        "updatedAt": "2023-12-08T19:01:24"
    },
    "id": 2,
    "createdAt": "2023-12-09T23:58:01",
    "updatedAt": "2023-12-09T23:58:01"
}