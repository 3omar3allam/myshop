import { CurrentUser } from "./current-user";

export interface LoginResponse extends CurrentUser{
    token: string;
    expiresAt: Date;
}