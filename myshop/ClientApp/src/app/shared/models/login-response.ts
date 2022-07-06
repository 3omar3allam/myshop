import { CurrentUser } from "./current-user";

export interface LoginResponse extends CurrentUser{
    expiresAt: Date;
}