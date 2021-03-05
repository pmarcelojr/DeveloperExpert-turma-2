import FavoriteMusic from "./favorite-music.model";

export default class User {
    public id?: string;
    public email?: string;
    public name?: string;
    public photo?: string;
    public favoriteMusics?: FavoriteMusic[];
}