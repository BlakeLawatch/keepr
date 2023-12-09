import { RepoItem } from "./RepoItem"

export class Keep extends RepoItem {
    constructor(data) {
        super(data)
        this.name = data.name
        this.description = data.description
        this.img = data.img
        this.views = data.views
        this.kept = data.kept
        this.creator = data.creator
        this.creatorId = data.creatorId
    }
}

const data = {
    "name": "Mindful Edited.",
    "description": "Nowhere is it disputed that the tricksome yarn comes from a tender back. The styleless geometry reveals itself as an undealt europe to those who look. A zone is the sidewalk of a pizza. If this was somewhat unclear, the first undrawn manager is, in its own way, a call. Edited.",
    "img": "https://images.unsplash.com/photo-1526566762798-8fac9c07aa98?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=768&h=722&q=60",
    "views": 0,
    "kept": 0,
    "creator": {
        "name": "anothernewemail@new.email",
        "picture": "https://s.gravatar.com/avatar/87d93fa56cfb84f69fde33613bc552ea?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fan.png",
        "id": "6541827fc58db642d7c02476",
        "createdAt": "2023-12-08T19:01:24",
        "updatedAt": "2023-12-08T19:01:24"
    },
    "creatorId": "6541827fc58db642d7c02476",
    "id": 2,
    "createdAt": "2023-12-08T19:28:20",
    "updatedAt": "2023-12-08T21:36:13"
}