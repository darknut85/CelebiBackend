import { Injectable } from "@angular/core";

@Injectable()
export class AuthService {
     
    constructor() { }
    
    login(res: string, user: string){
        localStorage.setItem("token_Id",res);
        localStorage.setItem("username",user);
    }

    logout() {
        localStorage.removeItem("token_Id");
        localStorage.removeItem("username");
    }

    public isLoggedIn() {
        return !this.getExpiration();
    }

    getExpiration() {
        const expiration = localStorage.getItem("token_Id");

        if(expiration != null)
        {
            const expiry = (JSON.parse(atob(expiration.split('.')[1]))).exp;
            return (Math.floor((new Date).getTime() / 1000)) >= expiry;
        }
        return;
    }

}