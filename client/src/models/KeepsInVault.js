import { RepoItem } from "./RepoItem";

export class KeepsInVault extends RepoItem {
    constructor(data) {
        super(data)
        this.vaultKeepId = data.vaultKeepId
        this.accountId = data.accountId
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
    "vaultKeepId": 105,
    "accountId": "6541827fc58db642d7c02476",
    "name": "Powerful",
    "description": "A wilderness of the children is assumed to be a fictile wholesaler.",
    "img": "https://images.unsplash.com/photo-1586695263077-6a2f79de6b09?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=562&h=745&q=60",
    "views": 0,
    "kept": 0,
    "creator": {
        "name": "Missy",
        "picture": "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1500w,f_auto,q_auto:best/rockcms/2023-09/kevin-james-king-of-queens-zz-230927-368fe6.jpg",
        "coverImg": "https://plus.unsplash.com/premium_photo-1674920184403-6228ef087971?auto=format&fit=crop&q=60&w=500&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8eWVsbG93JTIwc3ByaW5nc3xlbnwwfHwwfHx8MA%3D%3D",
        "id": "6541827fc58db642d7c02476",
        "createdAt": "2023-12-08T19:01:24",
        "updatedAt": "2023-12-11T05:02:32"
    },
    "creatorId": "6541827fc58db642d7c02476",
    "id": 77,
    "createdAt": "2023-12-11T18:45:38",
    "updatedAt": "2023-12-11T18:45:38"
}