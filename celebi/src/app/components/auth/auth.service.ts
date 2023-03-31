import { Injectable } from "@angular/core";

@Injectable()
export class AuthService {
     
    constructor() { }
      
    logout() {
        localStorage.removeItem("id_token");
        localStorage.removeItem("expires_at");
    }

    public isLoggedIn() {
        return !this.getExpiration();
    }

    isLoggedOut() {
        return !this.isLoggedIn();
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