import { RepoItem } from "./RepoItem";

export class VaultKeep extends RepoItem {
    constructor(data) {
        super(data)
        this.vaultId = data.vaultId
        this.keepId = data.keepId
        this.creator = data.creator
        this.creatorId = data.creatorId
    }


}

const data = {
    "creatorId": "6541827fc58db642d7c02476",
    "vaultId": 223,
    "keepId": 85,
    "creator": {
        "name": "Missy",
        "picture": "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1500w,f_auto,q_auto:best/rockcms/2023-09/kevin-james-king-of-queens-zz-230927-368fe6.jpg",
        "coverImg": "https://plus.unsplash.com/premium_photo-1674920184403-6228ef087971?auto=format&fit=crop&q=60&w=500&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8eWVsbG93JTIwc3ByaW5nc3xlbnwwfHwwfHx8MA%3D%3D",
        "id": "6541827fc58db642d7c02476",
        "createdAt": "2023-12-08T19:01:24",
        "updatedAt": "2023-12-11T05:02:32"
    },
    "id": 104,
    "createdAt": "2023-12-12T19:42:23",
    "updatedAt": "2023-12-12T19:42:23"
}