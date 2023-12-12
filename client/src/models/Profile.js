import { RepoItem } from "./RepoItem";

export class Profile {
    constructor(data) {
        // super(data)
        this.name = data.name
        this.picture = data.picture
        this.coverImg = data.coverImg
    }
}

const data = {
    "name": "heyitsme@its.me",
    "picture": "https://s.gravatar.com/avatar/469c061e9ec48a562bcbde38deafd05e?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fhe.png",
    "coverImg": null,
    "id": "65383a6f85a44e46777ed7d1",
    "createdAt": "2023-12-08T19:02:35",
    "updatedAt": "2023-12-08T19:02:35"
}